using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaAlClick : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string nombreEscena;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}