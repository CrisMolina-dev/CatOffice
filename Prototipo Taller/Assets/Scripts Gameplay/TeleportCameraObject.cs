using UnityEngine;

public class TeleportCameraObject : MonoBehaviour
{
    [Header("Objeto que activa el teletransporte")]
    public GameObject objetoActivador;

    [Header("Objeto a mover")]
    public Transform objetoAMover;

    [Header("Destino")]
    public Vector3 posicionDestino;
    public float rotacionYDestino;

    private Vector3 posicionAntesDelTeletransporte;
    private Quaternion rotacionAntesDelTeletransporte;

    private bool estadoAnterior;

    void Start()
    {
        if (objetoActivador != null)
            estadoAnterior = objetoActivador.activeInHierarchy;
    }

    void Update()
    {
        if (objetoActivador == null || objetoAMover == null)
            return;

        bool estadoActual = objetoActivador.activeInHierarchy;

        if (estadoActual != estadoAnterior)
        {
            if (estadoActual)
            {
                // Guardar posición y rotación actuales
                posicionAntesDelTeletransporte = objetoAMover.position;
                rotacionAntesDelTeletransporte = objetoAMover.rotation;

                // Teletransportar
                objetoAMover.position = posicionDestino;
                objetoAMover.rotation = Quaternion.Euler(
                    objetoAMover.eulerAngles.x,
                    rotacionYDestino,
                    objetoAMover.eulerAngles.z
                );
            }
            else
            {
                // Restaurar posición y rotación originales
                objetoAMover.position = posicionAntesDelTeletransporte;
                objetoAMover.rotation = rotacionAntesDelTeletransporte;
            }

            estadoAnterior = estadoActual;
        }
    }
}