using UnityEngine;

public class Ascensor : MonoBehaviour
{
    [Header("Objeto que debe estar activo")]
    public GameObject objetoRequerido;

    [Header("Sonido a reproducir")]
    public AudioClip sonido;

    [Range(0f, 1f)]
    public float volumen = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        // Solo reproduce el sonido si el objeto requerido está activo
        if (objetoRequerido != null && objetoRequerido.activeInHierarchy)
        {
            if (sonido != null)
            {
                audioSource.PlayOneShot(sonido, volumen);
            }
        }
    }
}
