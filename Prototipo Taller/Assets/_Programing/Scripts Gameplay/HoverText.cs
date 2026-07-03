using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelTexto;
    public TextMeshProUGUI textoUI;

    [TextArea]
    public string mensaje = "Texto de ejemplo";

    [Header("Offset del mouse")]
    public Vector2 offset = new Vector2(0, -40);

    private bool mouseEncima = false;

    void Start()
    {
        panelTexto.SetActive(false);
    }

    void Update()
    {
        if (mouseEncima)
        {
            
            panelTexto.transform.position =
                (Vector2)Input.mousePosition + offset;
        }
    }

    void OnMouseEnter()
    {
        mouseEncima = true;

        panelTexto.SetActive(true);
        textoUI.text = mensaje;
    }

    void OnMouseExit()
    {
        mouseEncima = false;

        panelTexto.SetActive(false);
    }
}