using UnityEngine;

public class RotarInfinito : MonoBehaviour
{
    [Header("Velocidad de rotación")]
    public float velocidad = 100f; // grados por segundo

    void Update()
    {
        // Rotación continua en eje Y
        transform.Rotate(0f, velocidad * Time.deltaTime, 0f);
    }
}