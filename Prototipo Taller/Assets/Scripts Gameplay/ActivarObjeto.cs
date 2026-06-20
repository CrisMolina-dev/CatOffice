using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoAActivar;
    public GameObject objetoADesactivar;

    void OnMouseDown()
    {
        
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (objetoADesactivar != null)
            {
                objetoADesactivar.SetActive(false);
            }
        }
    }
}