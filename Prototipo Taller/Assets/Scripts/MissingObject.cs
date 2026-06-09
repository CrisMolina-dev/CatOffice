using UnityEngine;

public class MissingObject : MonoBehaviour
{
    [Header("Hover")]
    public GameObject objetoHover;

    [Header("Objetos a activar al hacer clic")]
    public GameObject[] objetosAActivar;

    [Header("Objetos a desactivar al hacer clic")]
    public GameObject[] objetosADesactivar;

    private void OnMouseEnter()
    {
        if (objetoHover != null)
            objetoHover.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (objetoHover != null)
            objetoHover.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Activar todos los objetos de la lista
        foreach (GameObject obj in objetosAActivar)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        // Desactivar todos los objetos de la lista
        foreach (GameObject obj in objetosADesactivar)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
