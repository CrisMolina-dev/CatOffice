using UnityEngine;

public class ReproducirSonido : MonoBehaviour
{
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
        if (sonido != null)
        {
            audioSource.PlayOneShot(sonido, volumen);
        }
    }
}
