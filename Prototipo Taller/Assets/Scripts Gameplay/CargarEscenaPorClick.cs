using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargarEscenaPorClick : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string nombreEscena;

    [Header("Tiempo de espera (segundos)")]
    public float tiempoEspera = 2f;

    private void OnMouseDown()
    {
        StartCoroutine(CargarEscenaConDelay());
    }

    IEnumerator CargarEscenaConDelay()
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(nombreEscena);
    }
}