using UnityEngine;
using System.Collections.Generic;

public class ControlRotacionY : MonoBehaviour
{
    public List<GameObject> objetosAControlar;
    public float rotacionObjetivoY = 0f;
    public float tolerancia = 1f;

    private HashSet<GameObject> objetosDesactivadosPorEsteScript = new HashSet<GameObject>();

    void Update()
    {
        float rotY = transform.eulerAngles.y;
        float diferencia = Mathf.Abs(Mathf.DeltaAngle(rotY, rotacionObjetivoY));

        bool enObjetivo = diferencia <= tolerancia;

        foreach (GameObject obj in objetosAControlar)
        {
            if (obj == null) continue;

            if (enObjetivo)
            {
                // Solo lo apagamos si está activo
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                    objetosDesactivadosPorEsteScript.Add(obj);
                }
            }
            else
            {
                // Solo lo volvemos a activar si ESTE script lo apagó antes
                if (objetosDesactivadosPorEsteScript.Contains(obj))
                {
                    obj.SetActive(true);
                    objetosDesactivadosPorEsteScript.Remove(obj);
                }
            }
        }
    }
}