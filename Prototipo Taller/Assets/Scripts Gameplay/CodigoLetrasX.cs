using System.Collections;
using UnityEngine;

public class CodigoLetrasX : MonoBehaviour
{
    [Header("Rotación en X")]
    public float gradosRotacion = 60f;

    [Header("Velocidad de rotación")]
    public float velocidad = 2f;

    [Header("Objeto que se moverá")]
    public Transform objetoAMover;

    [Header("Movimiento en X")]
    public float incrementoX = 1f;

    [Header("Valor máximo de X")]
    public float maximoX = 5f;

    [Header("Sonido")]
    public AudioSource audioSource;
    public AudioClip sonidoMovimiento;

    private bool rotando = false;

    private void OnMouseDown()
    {
        if (!rotando)
        {
            // Reproducir sonido al hacer clic
            if (audioSource != null && sonidoMovimiento != null)
            {
                audioSource.PlayOneShot(sonidoMovimiento);
            }

            StartCoroutine(RotarSuavemente());
        }
    }

    IEnumerator RotarSuavemente()
    {
        rotando = true;

        Quaternion rotacionInicial = transform.rotation;
        Quaternion rotacionFinal = rotacionInicial * Quaternion.Euler(gradosRotacion, 0, 0);

        float progreso = 0f;

        while (progreso < 1f)
        {
            progreso += Time.deltaTime * velocidad;
            transform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, progreso);
            yield return null;
        }

        transform.rotation = rotacionFinal;

        if (objetoAMover != null)
        {
            Vector3 nuevaPosicion = objetoAMover.position;

            if (nuevaPosicion.x >= maximoX)
                nuevaPosicion.x = 0f;
            else
                nuevaPosicion.x += incrementoX;

            objetoAMover.position = nuevaPosicion;
        }

        rotando = false;
    }
}