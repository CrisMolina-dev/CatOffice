using UnityEngine;
using System.Collections;

public class DesactivarCollidersTemporal : MonoBehaviour
{
    [Header("Objetos cuyos colliders se desactivarán")]
    public GameObject[] objetos;

    [Header("Tiempo que estarán desactivados")]
    public float segundosDesactivados = 3f;

    private bool enEspera = false;

    void OnMouseDown()
    {
        if (!enEspera)
        {
            StartCoroutine(DesactivarColliders());
        }
    }

    IEnumerator DesactivarColliders()
    {
        enEspera = true;

        // Desactivar colliders
        foreach (GameObject obj in objetos)
        {
            if (obj != null)
            {
                Collider col = obj.GetComponent<Collider>();

                if (col != null)
                    col.enabled = false;
            }
        }

        yield return new WaitForSeconds(segundosDesactivados);

        // Reactivar colliders
        foreach (GameObject obj in objetos)
        {
            if (obj != null)
            {
                Collider col = obj.GetComponent<Collider>();

                if (col != null)
                    col.enabled = true;
            }
        }

        enEspera = false;
    }
}