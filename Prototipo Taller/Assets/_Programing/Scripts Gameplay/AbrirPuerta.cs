using UnityEngine;
using System.Collections;

public class AbrirPuerta : MonoBehaviour
{
    [Header("Objeto que se moverá")]
    public Transform objetoAMover;

    [Header("Objeto que debe estar activo")]
    public GameObject objetoRequerido;

    [Header("Posición X de destino")]
    public float posicionXDestino = 5f;

    [Header("Delay antes de mover (segundos)")]
    public float delay = 2f;

    [Header("Velocidad de movimiento")]
    public float velocidad = 2f;

    private bool moviendo = false;

    private void OnMouseDown()
    {
        // Solo funciona si el objeto requerido está activo
        if (objetoRequerido == null || !objetoRequerido.activeInHierarchy)
            return;

        if (!moviendo)
        {
            StartCoroutine(MoverConDelay());
        }
    }

    IEnumerator MoverConDelay()
    {
        moviendo = true;

        yield return new WaitForSeconds(delay);

        while (Mathf.Abs(objetoAMover.position.x - posicionXDestino) > 0.01f)
        {
            Vector3 posicionActual = objetoAMover.position;

            posicionActual.x = Mathf.MoveTowards(
                posicionActual.x,
                posicionXDestino,
                velocidad * Time.deltaTime
            );

            objetoAMover.position = posicionActual;

            yield return null;
        }

        Vector3 posicionFinal = objetoAMover.position;
        posicionFinal.x = posicionXDestino;
        objetoAMover.position = posicionFinal;

        moviendo = false;
    }
}