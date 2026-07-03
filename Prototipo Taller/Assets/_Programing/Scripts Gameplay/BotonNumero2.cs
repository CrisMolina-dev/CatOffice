using UnityEngine;

public class BotonNumero2 : MonoBehaviour
{
    public string numero1; // "1", "2", etc.

    public void Presionar()
    {
        KeypadManager2.instancia1.AgregarNumero(numero1);
    }
}