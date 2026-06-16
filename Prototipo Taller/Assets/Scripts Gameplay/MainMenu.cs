using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [Header("Tiempo de espera antes de cargar la escena")]
    public float tiempoEspera = 3f;

    public void Jugar()
    {
        StartCoroutine(CargarEscenaConDelay());
    }

    private IEnumerator CargarEscenaConDelay()
    {
        yield return new WaitForSeconds(tiempoEspera);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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