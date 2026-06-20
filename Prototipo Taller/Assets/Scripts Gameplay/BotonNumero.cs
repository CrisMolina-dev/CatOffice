using UnityEngine;

public class BotonNumero : MonoBehaviour
{
    public string numero; // "1", "2", etc.

    public void Presionar()
    {
        KeypadManager.instancia.AgregarNumero(numero);
    }
}