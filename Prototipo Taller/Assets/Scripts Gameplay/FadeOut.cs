using UnityEngine;
using System.Collections;

public class FadeOutPanel : MonoBehaviour
{
    [Header("Canvas Group del panel")]
    public CanvasGroup canvasGroup;

    [Header("Duración del fade (segundos)")]
    public float duracion = 2f;

    private void Start()
    {
        canvasGroup.alpha = 1f;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, tiempo / duracion);
            yield return null;
        }

        canvasGroup.alpha = 0f;

        // Desactiva el panel cuando termina el fade
        canvasGroup.gameObject.SetActive(false);
    }
}