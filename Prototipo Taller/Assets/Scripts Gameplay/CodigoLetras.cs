using System.Collections;
using UnityEngine;

public class CodigoLetras : MonoBehaviour
{
    [Header("Rotación en Z")]
    public float gradosRotacion = 70f;

    [Header("Velocidad de rotación")]
    public float velocidad = 2f;

    private bool rotando = false;

    private void OnMouseDown()
    {
        if (!rotando)
        {
            StartCoroutine(RotarSuavemente());
        }
    }

    IEnumerator RotarSuavemente()
    {
        rotando = true;

        Quaternion rotacionInicial = transform.rotation;
        Quaternion rotacionFinal = rotacionInicial * Quaternion.Euler(0, 0, gradosRotacion);

        float progreso = 0f;

        while (progreso < 1f)
        {
            progreso += Time.deltaTime * velocidad;
            transform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, progreso);
            yield return null;
        }

        transform.rotation = rotacionFinal;
        rotando = false;
    }
}
