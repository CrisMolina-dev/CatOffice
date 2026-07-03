using UnityEngine;

public class SimulateKey : MonoBehaviour
{
    public static KeyCode ultimaTeclaSimulada = KeyCode.None;
    private static bool teclaSimulada;

    [Header("Tecla a simular")]
    public KeyCode tecla;

    public void SimularTecla()
    {
        ultimaTeclaSimulada = tecla;
        teclaSimulada = true;
    }

    public static bool GetKeyDown(KeyCode key)
    {
        return (Input.GetKeyDown(key) ||
                (teclaSimulada && ultimaTeclaSimulada == key));
    }

    private void LateUpdate()
    {
        teclaSimulada = false;
        ultimaTeclaSimulada = KeyCode.None;
    }
}
