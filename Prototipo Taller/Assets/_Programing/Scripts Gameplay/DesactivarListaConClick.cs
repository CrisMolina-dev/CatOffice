using UnityEngine;

public class DesactivarListaConClick : MonoBehaviour
{
    [Header("Objetos a desactivar")]
    public GameObject[] objetosADesactivar;

    void OnMouseDown()
    {
        for (int i = 0; i < objetosADesactivar.Length; i++)
        {
            if (objetosADesactivar[i] != null)
            {
                objetosADesactivar[i].SetActive(false);
            }
        }
    }
}
