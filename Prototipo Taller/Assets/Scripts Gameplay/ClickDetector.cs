using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                BotonNumero boton = hit.collider.GetComponentInParent<BotonNumero>();
                if (boton != null)
                {
                    boton.Presionar();
                    return;
                }

                BotonBorrar borrar = hit.collider.GetComponentInParent<BotonBorrar>();
                if (borrar != null)
                {
                    borrar.Presionar();
                }
            }
        }
    }
}