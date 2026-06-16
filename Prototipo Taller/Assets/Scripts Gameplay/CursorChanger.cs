using UnityEngine;
using UnityEngine.InputSystem;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorHover;

    public Camera[] camaras; // ? puedes asignar varias cámaras

    private bool isHovering = false;

    void Update()
    {
        bool detectado = false;

        foreach (Camera cam in camaras)
        {
            if (cam == null) continue;

            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    detectado = true;
                    break;
                }
            }
        }

        if (detectado)
        {
            if (!isHovering)
            {
                Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
                isHovering = true;
            }
        }
        else
        {
            if (isHovering)
            {
                Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
                isHovering = false;
            }
        }
    }
}