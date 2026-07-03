using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscenaBoton : MonoBehaviour
{
    public string nombreEscena;

    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}