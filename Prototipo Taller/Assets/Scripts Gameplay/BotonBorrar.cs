using UnityEngine;

public class BotonBorrar : MonoBehaviour
{
    public bool borrarTodo = false;

    public void Presionar()
    {
        if (borrarTodo)
            KeypadManager.instancia.BorrarTodo();
        else
            KeypadManager.instancia.BorrarUltimo();
    }
}