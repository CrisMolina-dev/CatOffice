using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class LuzParpadeante : MonoBehaviour
{
    public Light luz;
    public TMP_Text texto;

    [Header("Parpadeo")]
    public int cantidadParpadeos = 10;
    public float tiempoMinimo = 0.05f;
    public float tiempoMaximo = 0.3f;

    [Header("Canvas Fade")]
    public float tiempoAntesDelFade = 2f;
    public GameObject canvasAActivar;
    public CanvasGroup canvasGroup;
    public float duracionFadeIn = 1f;
    public float tiempoVisible = 2f;
    public float duracionFadeOut = 1f;

    [Header("Objetos")]
    public List<GameObject> objetosAActivar = new List<GameObject>();
    public List<GameObject> objetosADesactivar = new List<GameObject>();

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light>();

        if (canvasGroup != null)
            canvasGroup.alpha = 0f;

        StartCoroutine(ParpadearYEncender());
    }

    IEnumerator ParpadearYEncender()
    {
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            luz.enabled = !luz.enabled;

            if (texto != null)
            {
                texto.color = luz.enabled ? Color.white : Color.black;
            }

            yield return new WaitForSeconds(
                Random.Range(tiempoMinimo, tiempoMaximo)
            );
        }

        // Encender definitivamente la luz
        luz.enabled = true;

        if (texto != null)
        {
            texto.color = Color.white;
        }

        // Esperar antes de iniciar el fade
        yield return new WaitForSeconds(tiempoAntesDelFade);

        // Activar canvas/panel
        if (canvasAActivar != null)
            canvasAActivar.SetActive(true);

        // Reiniciar alpha por si el objeto fue usado antes
        if (canvasGroup != null)
            canvasGroup.alpha = 0f;

        // Ejecutar Fade
        if (canvasGroup != null)
            yield return StartCoroutine(FadeCanvas());
    }

    IEnumerator FadeCanvas()
    {
        // Fade In
        float tiempo = 0f;

        while (tiempo < duracionFadeIn)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, tiempo / duracionFadeIn);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // Activar y desactivar objetos al terminar el Fade In
        foreach (GameObject obj in objetosAActivar)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        foreach (GameObject obj in objetosADesactivar)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // Mantener visible
        yield return new WaitForSeconds(tiempoVisible);

        // Fade Out
        tiempo = 0f;

        while (tiempo < duracionFadeOut)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, tiempo / duracionFadeOut);
            yield return null;
        }

        canvasGroup.alpha = 0f;

        // Desactivar el panel/canvas al terminar el Fade Out
        if (canvasAActivar != null)
        {
            canvasAActivar.SetActive(false);
        }
    }
}