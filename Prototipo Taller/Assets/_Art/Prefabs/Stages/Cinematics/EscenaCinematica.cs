using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class EscenaCinematica : MonoBehaviour
{
    [Header("Nombre de la escena")]
    public string nombreEscena;

    [Header("Tiempo de espera (segundos)")]
    public float tiempoEspera = 5f;

    void Start()
    {
        StartCoroutine(CargarEscena());
    }

    IEnumerator CargarEscena()
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(nombreEscena);
    }
}