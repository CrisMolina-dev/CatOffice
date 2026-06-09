using System.Collections;
using UnityEngine;

public class CodigoLetrasX : MonoBehaviour
{
    [Header("Rotación en X")]
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
        Quaternion rotacionFinal = rotacionInicial * Quaternion.Euler(gradosRotacion, 0, 0);

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