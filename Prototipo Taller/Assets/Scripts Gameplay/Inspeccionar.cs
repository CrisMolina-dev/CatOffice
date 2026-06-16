using UnityEngine;

public class Inspeccionar : MonoBehaviour
{
    public float velocidadRotacion = 200f;
    public float velocidadRetorno = 5f;

    public Camera[] camaras;

    
    public Vector3 correccionRotacion = new Vector3(0f, -90f, 270f);

    private bool estaSeleccionado = false;
    private bool volverARotacionInicial = false;

    private Quaternion rotacionInicial;

    void OnEnable()
    {
        Camera cam = ObtenerCamaraValida();

        if (cam != null)
        {
            transform.LookAt(cam.transform);
            transform.Rotate(correccionRotacion);
        }

        rotacionInicial = transform.rotation;

        estaSeleccionado = false;
        volverARotacionInicial = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (DetectarClickEnEsteObjeto())
            {
                estaSeleccionado = true;
            }
        }

        if (Input.GetMouseButton(0) && estaSeleccionado && !volverARotacionInicial)
        {
            float movimientoX = Input.GetAxis("Mouse X");
            float movimientoY = Input.GetAxis("Mouse Y");

            Camera cam = ObtenerCamaraValida();

            if (cam != null)
            {
                float rotX = -movimientoX * velocidadRotacion * Time.deltaTime;
                float rotY = movimientoY * velocidadRotacion * Time.deltaTime;

                Quaternion rotacionX = Quaternion.AngleAxis(rotX, cam.transform.up);
                Quaternion rotacionY = Quaternion.AngleAxis(rotY, cam.transform.right);

                transform.rotation = rotacionX * rotacionY * transform.rotation;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            estaSeleccionado = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            volverARotacionInicial = true;
        }

        if (volverARotacionInicial)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionInicial, Time.deltaTime * velocidadRetorno);

            if (Quaternion.Angle(transform.rotation, rotacionInicial) < 0.1f)
            {
                transform.rotation = rotacionInicial;
                volverARotacionInicial = false;
            }
        }
    }

    bool DetectarClickEnEsteObjeto()
    {
        foreach (Camera cam in camaras)
        {
            if (cam == null) continue;

            Ray rayo = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit))
            {
                if (hit.transform == transform)
                {
                    return true;
                }
            }
        }
        return false;
    }

    Camera ObtenerCamaraValida()
    {
        foreach (Camera cam in camaras)
        {
            if (cam != null && cam.isActiveAndEnabled)
                return cam;
        }
        return null;
    }
}