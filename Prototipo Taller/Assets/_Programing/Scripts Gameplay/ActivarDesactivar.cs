using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    public GameObject objetoControlador;
    public GameObject objetoObjetivo;

    void Update()
    {
        // Si el controlador está activo ? desactivar objetivo
        if (objetoControlador.activeSelf && objetoObjetivo.activeSelf)
        {
            objetoObjetivo.SetActive(false);
        }
        // Si el controlador está desactivo ? activar objetivo
        else if (!objetoControlador.activeSelf && !objetoObjetivo.activeSelf)
        {
            objetoObjetivo.SetActive(true);
        }
    }
}