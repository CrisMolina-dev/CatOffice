using UnityEngine;

public class DesactivarSiActivo : MonoBehaviour
{
    public GameObject objetoADesactivar;

    void OnEnable()
    {
        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(false);
        }
    }
}