using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToRotate : MonoBehaviour
{
    public Transform objetoARotar;
    public GameObject objetoAActivar;

    public float grados = 45f;
    public float velocidadRotacion = 5f;

    private Quaternion rotacionObjetivo;
    private bool rotando = false;

    void Start()
    {
        if (objetoARotar != null)
        {
            rotacionObjetivo = objetoARotar.rotation;
        }
    }

    void Update()
    {
        // Solo permitir click si NO está rotando
        if (!rotando && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform && objetoARotar != null)
                {
                    // Rotación en eje X global
                    rotacionObjetivo = Quaternion.AngleAxis(grados, Vector3.right) * objetoARotar.rotation;
                    rotando = true;
                }
            }
        }

        // Rotación suave
        if (rotando && objetoARotar != null)
        {
            objetoARotar.rotation = Quaternion.Lerp(
                objetoARotar.rotation,
                rotacionObjetivo,
                Time.deltaTime * velocidadRotacion
            );

            // Cuando termina la rotación
            if (Quaternion.Angle(objetoARotar.rotation, rotacionObjetivo) < 0.1f)
            {
                objetoARotar.rotation = rotacionObjetivo;
                rotando = false;

                // 🔥 Verificar SOLO aquí (cuando terminó)
                float x = objetoARotar.eulerAngles.x;

                if (Mathf.Abs(x) < 0.1f || Mathf.Abs(x - 360f) < 0.1f)
                {
                    objetoAActivar.SetActive(true);
                }
                else
                {
                    objetoAActivar.SetActive(false);
                }
            }
        }
    }
}