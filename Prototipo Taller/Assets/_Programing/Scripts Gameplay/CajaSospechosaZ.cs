using UnityEngine;

public class CajaSospechosaZ : MonoBehaviour
{
    [Header("Ángulo Z de destino")]
    public float anguloZDestino = 180f;

    [Header("Velocidad de rotación")]
    public float velocidadRotacion = 100f;

    private Quaternion rotacionInicial;
    private Quaternion rotacionDestino;
    private Quaternion objetivoActual;

    private bool rotando = false;
    private bool enDestino = false;

    private void Start()
    {
        rotacionInicial = transform.rotation;

        rotacionDestino = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            anguloZDestino
        );
    }

    private void OnMouseDown()
    {
        if (enDestino)
        {
            objetivoActual = rotacionInicial;
        }
        else
        {
            objetivoActual = rotacionDestino;
        }

        enDestino = !enDestino;
        rotando = true;
    }

    private void Update()
    {
        if (rotando)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                objetivoActual,
                velocidadRotacion * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, objetivoActual) < 0.1f)
            {
                transform.rotation = objetivoActual;
                rotando = false;
            }
        }
    }
}
