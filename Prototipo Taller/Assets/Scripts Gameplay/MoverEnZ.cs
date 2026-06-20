using UnityEngine;
using System.Collections;

public class MoverEnZ : MonoBehaviour
{
    [Header("Posición Z de destino")]
    public float destinoZ = 5f;

    [Header("Velocidad de movimiento")]
    public float velocidad = 2f;

    private bool moviendo = false;

    private void OnMouseDown()
    {
        if (!moviendo)
        {
            StartCoroutine(Mover());
        }
    }

    IEnumerator Mover()
    {
        moviendo = true;

        Vector3 destino = new Vector3(
            transform.position.x,
            transform.position.y,
            destinoZ
        );

        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino,
                velocidad * Time.deltaTime
            );

            yield return null;
        }

        transform.position = destino;
        moviendo = false;
    }
}