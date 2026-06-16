using UnityEngine;
using System.Collections;

public class Zzz : MonoBehaviour
{
    [Header("Objeto a mover")]
    public GameObject objetoAMover;

    [Header("Posición destino")]
    public float destinoX;
    public float destinoY;

    [Header("Velocidad")]
    public float velocidad = 2f;

    [Header("Tiempos")]
    public float segundosDesactivado = 3f;         // Tiempo inicial apagado
    public float segundosActivado = 5f;            // Tiempo encendido
    public float segundosDesactivadoDespues = 8f;  // Tiempo apagado después de cada activación

    private Vector3 posicionInicial;
    private Vector3 posicionDestino;
    private bool yendoAlDestino = true;

    void Start()
    {
        if (objetoAMover != null)
        {
            posicionInicial = objetoAMover.transform.position;

            posicionDestino = new Vector3(
                destinoX,
                destinoY,
                posicionInicial.z
            );

            // Comienza desactivado
            objetoAMover.SetActive(false);

            StartCoroutine(CicloActivacion());
        }
    }

    void Update()
    {
        if (objetoAMover == null || !objetoAMover.activeSelf)
            return;

        Vector3 objetivo = yendoAlDestino ? posicionDestino : posicionInicial;

        objetoAMover.transform.position = Vector3.MoveTowards(
            objetoAMover.transform.position,
            objetivo,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(objetoAMover.transform.position, objetivo) < 0.01f)
        {
            objetoAMover.transform.position = objetivo;
            yendoAlDestino = !yendoAlDestino;
        }
    }

    IEnumerator CicloActivacion()
    {
        while (true)
        {
            // Primer tiempo (apagado)
            objetoAMover.SetActive(false);
            yield return new WaitForSeconds(segundosDesactivado);

            // Segundo tiempo (encendido)
            objetoAMover.SetActive(true);
            yield return new WaitForSeconds(segundosActivado);

            // Tercer tiempo (apagado)
            objetoAMover.SetActive(false);
            yield return new WaitForSeconds(segundosDesactivadoDespues);
        }
    }
}