using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInDialogue : MonoBehaviour
{
    public float tiempoEspera = 2f;
    public float duracionFade = 1f;

    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        canvasGroup.alpha = 0f;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        canvasGroup.alpha = 0f;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(tiempoEspera);

        float tiempo = 0f;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, tiempo / duracionFade);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}