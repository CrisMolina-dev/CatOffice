using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FadeInStory : MonoBehaviour
{
    [Header("Panel a mostrar")]
    public GameObject panel;

    [Header("Imagen del panel")]
    public Image imagenPanel;

    [Header("Duración del fade")]
    public float duracionFade = 2f;

    private void OnMouseDown()
    {
        panel.SetActive(true);

        Color color = imagenPanel.color;
        color.a = 0f;
        imagenPanel.color = color;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float tiempo = 0f;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;

            Color color = imagenPanel.color;
            color.a = Mathf.Lerp(0f, 1f, tiempo / duracionFade);
            imagenPanel.color = color;

            yield return null;
        }

        Color colorFinal = imagenPanel.color;
        colorFinal.a = 1f;
        imagenPanel.color = colorFinal;
    }
}
