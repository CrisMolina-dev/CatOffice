using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class RotarObjeto : MonoBehaviour
{
    public float anguloRotacion = 90f;
    public float velocidad = 200f;

    public List<GameObject> objetosQueBloquean; 

    private bool rotando = false;
    private Quaternion rotacionObjetivo;

    public void RotarDerecha()
    {
        if (!rotando)
        {
            rotacionObjetivo = transform.rotation * Quaternion.Euler(0, anguloRotacion, 0);
            rotando = true;
        }
    }

    public void RotarIzquierda()
    {
        if (!rotando)
        {
            rotacionObjetivo = transform.rotation * Quaternion.Euler(0, -anguloRotacion, 0);
            rotando = true;
        }
    }

    void Update()
    {
        //bloquear input
        if (HayObjetoBloqueando())
        {
            return;
        }

        //rotar derecha
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            RotarDerecha();
        }

        // izquierda
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            RotarIzquierda();
        }

        if (rotando)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacionObjetivo,
                velocidad * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, rotacionObjetivo) < 0.1f)
            {
                transform.rotation = rotacionObjetivo;
                rotando = false;
            }
        }
    }

    bool HayObjetoBloqueando()
    {
        if (objetosQueBloquean == null) return false;

        foreach (GameObject obj in objetosQueBloquean)
        {
            if (obj != null && obj.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
}