using UnityEngine;

public class PuzzlesLetras : MonoBehaviour
{
    [Header("Primer objeto a vigilar")]
    public Transform objetoControl1;
    public float xObjetivo1 = 5f;

    [Header("Segundo objeto a vigilar")]
    public Transform objetoControl2;
    public float xObjetivo2 = 5f;

    [Header("Tercer objeto a vigilar")]
    public Transform objetoControl3;
    public float xObjetivo3 = 5f;

    [Header("Objeto que se moverá")]
    public Transform objetoAMover;
    public float xDestino = 10f;
    public float velocidad = 2f;

    [Header("Objeto que rotará en Y")]
    public Transform objetoARotar;
    public float gradosRotacionY = 90f;
    public float velocidadRotacion = 90f;

    [Header("Objeto a activar")]
    public GameObject objetoAActivar;

    private bool activarAccion = false;
    private Quaternion rotacionObjetivo;

    void Update()
    {
        bool objeto1Listo = Mathf.Abs(objetoControl1.position.x - xObjetivo1) < 0.01f;
        bool objeto2Listo = Mathf.Abs(objetoControl2.position.x - xObjetivo2) < 0.01f;
        bool objeto3Listo = Mathf.Abs(objetoControl3.position.x - xObjetivo3) < 0.01f;

        // Solo comienza cuando los 3 estén en la posición requerida
        if (!activarAccion && objeto1Listo && objeto2Listo && objeto3Listo)
        {
            activarAccion = true;

            // Preparar rotación
            if (objetoARotar != null)
            {
                rotacionObjetivo = objetoARotar.rotation *
                                   Quaternion.Euler(0f, gradosRotacionY, 0f);
            }

            // Activar objeto
            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }
        }

        if (activarAccion)
        {
            // Mover objeto
            if (objetoAMover != null)
            {
                Vector3 destino = objetoAMover.position;
                destino.x = xDestino;

                objetoAMover.position = Vector3.MoveTowards(
                    objetoAMover.position,
                    destino,
                    velocidad * Time.deltaTime
                );
            }

            // Rotar objeto en Y
            if (objetoARotar != null)
            {
                objetoARotar.rotation = Quaternion.RotateTowards(
                    objetoARotar.rotation,
                    rotacionObjetivo,
                    velocidadRotacion * Time.deltaTime
                );
            }
        }
    }
}