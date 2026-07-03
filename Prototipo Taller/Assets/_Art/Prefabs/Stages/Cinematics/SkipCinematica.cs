using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SkipCinematica : MonoBehaviour
{
    [Header("Imagen con Fill")]
    public Image barra;

    [Header("Velocidades")]
    public float velocidadLlenado = 0.5f;
    public float velocidadVaciado = 0.3f;

    [Header("Objeto a activar")]
    public GameObject objetoAActivar;

    [Header("Carga de escena")]
    public float tiempoEspera = 3f;

    private bool completado = false;

    void Update()
    {
        if (completado)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            barra.fillAmount += velocidadLlenado * Time.deltaTime;
        }
        else
        {
            barra.fillAmount -= velocidadVaciado * Time.deltaTime;
        }

        barra.fillAmount = Mathf.Clamp01(barra.fillAmount);

        if (barra.fillAmount >= 1f)
        {
            completado = true;

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }

            StartCoroutine(CargarSiguienteEscena());
        }
    }

    private IEnumerator CargarSiguienteEscena()
    {
        yield return new WaitForSeconds(tiempoEspera);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}