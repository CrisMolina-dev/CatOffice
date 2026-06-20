using UnityEngine;

public class PuertaFusible : MonoBehaviour
{
    [Header("Ángulo Y de destino")]
    public float anguloYDestino = 180f;

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
            anguloYDestino,
            transform.eulerAngles.z
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
