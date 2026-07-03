using UnityEngine;

public class CambiarObjetos : MonoBehaviour
{
    [Header("Objeto que se activará")]
    public GameObject objetoActivar;

    [Header("Objeto que se desactivará")]
    public GameObject objetoDesactivar;

    // Esta función se llama desde el botón
    public void CambiarEstado()
    {
        if (objetoActivar != null)
            objetoActivar.SetActive(true);

        if (objetoDesactivar != null)
            objetoDesactivar.SetActive(false);
    }
}