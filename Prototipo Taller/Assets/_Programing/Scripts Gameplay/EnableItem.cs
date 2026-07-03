using UnityEngine;
using System.Collections;

public class EnableItem : MonoBehaviour
{
    [Header("Objeto que debe estar activo")]
    public GameObject objetoRequerido;

    [Header("Objeto que rotará")]
    public Transform objetoARotar;

    [Header("Rotación en Y")]
    public float gradosRotacion = 90f;

    [Header("Duración de la rotación")]
    public float duracionRotacion = 1f;

    [Header("Objeto que se moverá")]
    public Transform objetoAMover;

    [Header("Posición Y destino")]
    public float posicionYDestino = 5f;

    [Header("Retraso antes de mover (segundos)")]
    public float retrasoMovimiento = 1f;

    [Header("Duración del movimiento")]
    public float duracionMovimiento = 2f;

    [Header("Objeto a destruir inmediatamente")]
    public GameObject objetoADestruir;

    [Header("Objetos a destruir después del retraso")]
    public GameObject[] objetosADestruirConRetraso;

    [Header("Retraso para destruir los objetos")]
    public float retrasoDestruccion = 2f;

    [Header("Objetos a activar cuando se destruyan los objetos")]
    public GameObject[] objetosAActivar;

    [Header("Sonido al hacer clic correctamente")]
    public AudioSource audioSourceCorrecto;

    [Header("Sonido cuando falta el objeto requerido")]
    public AudioSource audioSourceError;

    private bool yaEjecutado = false;
    private bool enProceso = false;

    private void OnMouseDown()
    {
        // Si no está activo el objeto requerido, reproducir sonido de error
        if (objetoRequerido == null || !objetoRequerido.activeInHierarchy)
        {
            if (audioSourceError != null)
            {
                audioSourceError.Play();
            }

            return;
        }

        // Solo ejecutar una vez
        if (yaEjecutado || enProceso)
            return;

        enProceso = true;

        // Reproducir sonido correcto
        if (audioSourceCorrecto != null)
        {
            audioSourceCorrecto.Play();
        }

        // Destruir inmediatamente
        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir);
        }

        StartCoroutine(DestruirYActivar());
        StartCoroutine(Rotar());
        StartCoroutine(MoverConRetraso());
    }

    IEnumerator Rotar()
    {
        Quaternion rotacionInicial = objetoARotar.rotation;
        Quaternion rotacionFinal = rotacionInicial * Quaternion.Euler(0, gradosRotacion, 0);

        float tiempo = 0f;

        while (tiempo < duracionRotacion)
        {
            tiempo += Time.deltaTime;

            float t = Mathf.Clamp01(tiempo / duracionRotacion);

            objetoARotar.rotation = Quaternion.Slerp(
                rotacionInicial,
                rotacionFinal,
                t
            );

            yield return null;
        }

        objetoARotar.rotation = rotacionFinal;
    }

    IEnumerator MoverConRetraso()
    {
        yield return new WaitForSeconds(retrasoMovimiento);

        Vector3 posicionInicial = objetoAMover.position;
        Vector3 posicionFinal = new Vector3(
            posicionInicial.x,
            posicionYDestino,
            posicionInicial.z
        );

        float tiempo = 0f;

        while (tiempo < duracionMovimiento)
        {
            tiempo += Time.deltaTime;

            float t = Mathf.Clamp01(tiempo / duracionMovimiento);

            objetoAMover.position = Vector3.Lerp(
                posicionInicial,
                posicionFinal,
                t
            );

            yield return null;
        }

        objetoAMover.position = posicionFinal;

        yaEjecutado = true;
        enProceso = false;
    }

    IEnumerator DestruirYActivar()
    {
        yield return new WaitForSeconds(retrasoDestruccion);

        // Destruir todos los objetos de la lista
        foreach (GameObject obj in objetosADestruirConRetraso)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        // Activar todos los objetos de la lista
        foreach (GameObject obj in objetosAActivar)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}