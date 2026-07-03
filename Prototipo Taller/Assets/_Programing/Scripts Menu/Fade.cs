using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    [Header("Panel con CanvasGroup")]
    public CanvasGroup panel;

    [Header("Audio a desvanecer")]
    public AudioSource audioSource;

    [Header("Duración del fade")]
    public float duracion = 2f;

    public void ActivarPanelYMostrar()
    {
        panel.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        panel.alpha = 0f;

        float volumenInicial = audioSource.volume;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion;

            
            panel.alpha = Mathf.Lerp(0f, 1f, progreso);

            
            audioSource.volume = Mathf.Lerp(volumenInicial, 0f, progreso);

            yield return null;
        }

        panel.alpha = 1f;
        audioSource.volume = 0f;
    }
}