using UnityEngine;

public class Movimiento8 : MonoBehaviour
{
    [Header("Tamaño del movimiento")]
    public float amplitudX = 100f;
    public float amplitudY = 50f;

    [Header("Velocidad")]
    public float velocidad = 1f;

    private RectTransform rectTransform;
    private Vector2 posicionInicial;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posicionInicial = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float t = Time.time * velocidad;

        float x = Mathf.Sin(t) * amplitudX;
        float y = Mathf.Sin(t * 2) * amplitudY * 0.5f;

        rectTransform.anchoredPosition = posicionInicial + new Vector2(x, y);
    }
}
