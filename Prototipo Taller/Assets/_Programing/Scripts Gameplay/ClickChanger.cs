using UnityEngine;

public class ClickChanger : MonoBehaviour
{
    [Header("Cursores")]
    public Texture2D cursorNormal;
    public Texture2D cursorClick;

    [Header("Configuración")]
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        
        Cursor.SetCursor(cursorNormal, hotspot, cursorMode);
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorClick, hotspot, cursorMode);
        }

        
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hotspot, cursorMode);
        }
    }
}
