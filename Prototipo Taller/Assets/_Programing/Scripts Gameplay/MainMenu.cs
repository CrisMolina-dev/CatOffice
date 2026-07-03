using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [Header("Tiempo de espera antes de cargar la escena")]
    public float tiempoEspera = 3f;

    [Header("Escena a cargar")]
    public string nombreEscena;   
    public int indiceEscena;      

    public bool usarNombre = true; 

    public void Jugar()
    {
        StartCoroutine(CargarEscenaConDelay());
    }

    private IEnumerator CargarEscenaConDelay()
    {
        yield return new WaitForSeconds(tiempoEspera);

        if (usarNombre)
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            SceneManager.LoadScene(indiceEscena);
        }
    }

    public void Creditos()
    {
        Application.Quit();
    }

    public void Salir()
    {
        Application.Quit();
    }
}