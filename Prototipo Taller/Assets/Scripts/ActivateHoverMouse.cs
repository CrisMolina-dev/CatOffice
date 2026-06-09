using UnityEngine;

public class ActivateHoverMouse : MonoBehaviour
{
    [Header("Objeto que se activará")]
    public GameObject objetoActivar;

    [Header("Opcional")]
    public bool desactivarAlSalir = true;

    private void OnMouseEnter()
    {
        if (objetoActivar != null)
        {
            objetoActivar.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (desactivarAlSalir && objetoActivar != null)
        {
            objetoActivar.SetActive(false);
        }
    }
}
