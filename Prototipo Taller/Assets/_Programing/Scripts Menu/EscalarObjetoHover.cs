using UnityEngine;
using UnityEngine.EventSystems;

public class EscalarObjetoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Objeto a escalar")]
    public Transform objetoAEscalar;

    [Header("Escala X al pasar el mouse")]
    public float escalaXHover = 2f;

    [Header("Velocidad de escalado")]
    public float velocidad = 5f;

    [Header("Audio Source")]
    public AudioSource audioSource;

    private Vector3 escalaOriginal;
    private Vector3 escalaObjetivo;
    private float escalaXAnterior;

    private void Start()
    {
        escalaOriginal = objetoAEscalar.localScale;
        escalaObjetivo = escalaOriginal;

        escalaXAnterior = objetoAEscalar.localScale.x;
    }

    private void Update()
    {
        objetoAEscalar.localScale = Vector3.Lerp(
            objetoAEscalar.localScale,
            escalaObjetivo,
            velocidad * Time.deltaTime
        );

        float escalaXActual = objetoAEscalar.localScale.x;

        // Reproduce el audio mientras la escala X aumenta
        if (audioSource != null)
        {
            if (escalaXActual > escalaXAnterior + 0.001f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }

        escalaXAnterior = escalaXActual;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaObjetivo = new Vector3(
            escalaXHover,
            escalaOriginal.y,
            escalaOriginal.z
        );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RestaurarEscala();
    }

    private void OnDisable()
    {
        RestaurarEscala();
    }

    private void RestaurarEscala()
    {
        escalaObjetivo = escalaOriginal;

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (objetoAEscalar != null)
        {
            objetoAEscalar.localScale = escalaOriginal;
        }
    }
}