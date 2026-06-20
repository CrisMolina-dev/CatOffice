using UnityEngine;
using System.Collections.Generic;

public class BloquearMovimiento : MonoBehaviour
{
    [Header("Objetos que bloquean")]
    public List<GameObject> objetosQueBloquean = new List<GameObject>();

    public static bool bloqueoActivo = false;

    void Update()
    {
        bloqueoActivo = false;

        foreach (GameObject obj in objetosQueBloquean)
        {
            if (obj != null && obj.activeSelf)
            {
                bloqueoActivo = true;
                break;
            }
        }
    }
}