using UnityEngine;
using UnityEngine.InputSystem;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorHover;

    public Camera camara; // Solo una cámara

    private bool isHovering = false;

    void Update()
    {
        if (camara == null) return;

        Ray ray = camara.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        bool detectado = Physics.Raycast(ray, out hit) &&
                         hit.collider.gameObject == gameObject;

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