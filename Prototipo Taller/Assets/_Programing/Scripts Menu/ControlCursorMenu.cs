using UnityEngine;

public class ControlCursorMenu : MonoBehaviour
{
    public GameObject objetoReferencia;

    void Update()
    {
        if (objetoReferencia != null && objetoReferencia.activeInHierarchy)
        {
            BloquearCursor();
        }
        else
        {
            LiberarCursor();
        }
    }

    void BloquearCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LiberarCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        if (objetoReferencia != null && objetoReferencia.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}