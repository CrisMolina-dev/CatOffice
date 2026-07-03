using UnityEngine;

public class ArrastrarObjeto : MonoBehaviour
{
    public Camera camara;
    public float distancia = 3f;

    private bool agarrado = false;
    private float distanciaCamara;

    void Start()
    {
        if (camara == null)
            camara = Camera.main;
    }

    void OnMouseDown()
    {
        agarrado = true;

        
        distanciaCamara = Vector3.Distance(camara.transform.position, transform.position);
    }

    void OnMouseUp()
    {
        agarrado = false;
    }

    void Update()
    {
        if (agarrado)
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);

            Vector3 punto = ray.GetPoint(distanciaCamara);

            transform.position = punto;
        }
    }
}