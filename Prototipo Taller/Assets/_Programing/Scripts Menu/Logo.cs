using UnityEngine;
using TMPro;
using System.Collections;

public class Logo : MonoBehaviour
{
    [Header("Texto")]
    public TMP_Text textoUI;

    [TextArea(3, 10)]
    public string mensaje;

    public float tiempoEntreLetras = 0.05f;

    [Header("Movimiento")]
    public Transform objetoAMover;
    public float distanciaZ = 5f;
    public float velocidadMovimiento = 2f;

    [Header("Objetos a activar al finalizar")]
    public GameObject[] objetosAActivar;

    private void Start()
    {
        StartCoroutine(EscribirTexto());
    }

    IEnumerator EscribirTexto()
    {
        textoUI.text = "";

        foreach (char letra in mensaje)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }

        StartCoroutine(MoverObjeto());
    }

    IEnumerator MoverObjeto()
    {
        Vector3 posicionInicial = objetoAMover.position;
        Vector3 posicionFinal = posicionInicial + new Vector3(0, 0, distanciaZ);

        while (Vector3.Distance(objetoAMover.position, posicionFinal) > 0.01f)
        {
            objetoAMover.position = Vector3.MoveTowards(
                objetoAMover.position,
                posicionFinal,
                velocidadMovimiento * Time.deltaTime
            );

            yield return null;
        }

        objetoAMover.position = posicionFinal;

        
        foreach (GameObject objeto in objetosAActivar)
        {
            if (objeto != null)
            {
                objeto.SetActive(true);
            }
        }
    }
}