using System.Collections.Generic;
using UnityEngine;

public class Optimizacion : MonoBehaviour
{
    [Header("Objeto a vigilar")]
    public Transform objetoAVigilar;

    [Header("Objetivo Y 1")]
    public float posicionYObjetivo1 = 5f;
    public float tolerancia1 = 0.1f;
    public List<GameObject> objetosGrupo1 = new List<GameObject>();

    [Header("Objetivo Y 2")]
    public float posicionYObjetivo2 = 10f;
    public float tolerancia2 = 0.1f;
    public List<GameObject> objetosGrupo2 = new List<GameObject>();

    [Header("Objetivo Y 3")]
    public float posicionYObjetivo3 = 15f;
    public float tolerancia3 = 0.1f;
    public List<GameObject> objetosGrupo3 = new List<GameObject>();

    [Header("Objetivo Y 4")]
    public float posicionYObjetivo4 = 20f;
    public float tolerancia4 = 0.1f;
    public List<GameObject> objetosGrupo4 = new List<GameObject>();

    [Header("Objetivo Y 5")]
    public float posicionYObjetivo5 = 25f;
    public float tolerancia5 = 0.1f;
    public List<GameObject> objetosGrupo5 = new List<GameObject>();

    void Update()
    {
        bool enPosicion1 = Mathf.Abs(objetoAVigilar.position.y - posicionYObjetivo1) <= tolerancia1;
        bool enPosicion2 = Mathf.Abs(objetoAVigilar.position.y - posicionYObjetivo2) <= tolerancia2;
        bool enPosicion3 = Mathf.Abs(objetoAVigilar.position.y - posicionYObjetivo3) <= tolerancia3;
        bool enPosicion4 = Mathf.Abs(objetoAVigilar.position.y - posicionYObjetivo4) <= tolerancia4;
        bool enPosicion5 = Mathf.Abs(objetoAVigilar.position.y - posicionYObjetivo5) <= tolerancia5;

        HashSet<GameObject> todosLosObjetos = new HashSet<GameObject>();

        foreach (GameObject obj in objetosGrupo1)
            if (obj != null) todosLosObjetos.Add(obj);

        foreach (GameObject obj in objetosGrupo2)
            if (obj != null) todosLosObjetos.Add(obj);

        foreach (GameObject obj in objetosGrupo3)
            if (obj != null) todosLosObjetos.Add(obj);

        foreach (GameObject obj in objetosGrupo4)
            if (obj != null) todosLosObjetos.Add(obj);

        foreach (GameObject obj in objetosGrupo5)
            if (obj != null) todosLosObjetos.Add(obj);

        foreach (GameObject obj in todosLosObjetos)
        {
            bool desactivar =
                (objetosGrupo1.Contains(obj) && enPosicion1) ||
                (objetosGrupo2.Contains(obj) && enPosicion2) ||
                (objetosGrupo3.Contains(obj) && enPosicion3) ||
                (objetosGrupo4.Contains(obj) && enPosicion4) ||
                (objetosGrupo5.Contains(obj) && enPosicion5);

            obj.SetActive(!desactivar);
        }
    }
}