using UnityEngine;
using UnityEngine.EventSystems;

public class EscalarObjetoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Objeto a escalar")]
    public Transform objetoAEscalar;

    [Header("Escala X al pasar el mouse")]
    public float escalaXHover = 2f;

    [Header("Velocidad de escalado")]
    public float velocidad = 5f;

    private Vector3 escalaOriginal;
    private Vector3 escalaObjetivo;

    private void Start()
    {
        escalaOriginal = objetoAEscalar.localScale;
        escalaObjetivo = escalaOriginal;
    }

    private void Update()
    {
        objetoAEscalar.localScale = Vector3.Lerp(
            objetoAEscalar.localScale,
            escalaObjetivo,
            velocidad * Time.deltaTime
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaObjetivo = new Vector3(
            escalaXHover,
            escalaOriginal.y,
            escalaOriginal.z
        );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RestaurarEscala();
    }

    private void OnDisable()
    {
        RestaurarEscala();
    }

    private void RestaurarEscala()
    {
        escalaObjetivo = escalaOriginal;

        if (objetoAEscalar != null)
        {
            objetoAEscalar.localScale = escalaOriginal;
        }
    }
}