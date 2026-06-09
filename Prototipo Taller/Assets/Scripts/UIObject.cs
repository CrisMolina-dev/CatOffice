using UnityEngine;

public class UIObject : MonoBehaviour
{
    [Header("Objeto a activar")]
    public GameObject objetoAActivar;

    [Header("Objeto a desactivar")]
    public GameObject objetoADesactivar;

    private void OnMouseDown()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }

        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(false);
        }
    }
}
