using UnityEngine;
using System.Collections;

public class Llave : MonoBehaviour
{
    [Header("Objeto a activar")]
    public GameObject objetoAActivar;

    [Header("Audio")]
    public AudioSource audioSource;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }

        // Ocultar el objeto
        if (meshRenderer != null)
            meshRenderer.enabled = false;

        // Desactivar el collider
        if (boxCollider != null)
            boxCollider.enabled = false;

        // Reproducir sonido y destruir al terminar
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            StartCoroutine(DestruirDespuesDelSonido());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestruirDespuesDelSonido()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}