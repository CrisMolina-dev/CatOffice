using System.Collections;
using UnityEngine;

public class MoverObjetoPorClick : MonoBehaviour
{
    [Header("Primer objeto que se moverá")]
    public Transform objetoAMover;
    public Vector3 posicionDestino;

    [Header("Segundo objeto que se moverá en X")]
    public Transform segundoObjeto;
    public float posicionXDestino = 5f;

    [Header("Tercer objeto que se moverá en X")]
    public Transform tercerObjeto;
    public float posicionXDestinoTercerObjeto = 10f;

    [Header("Velocidad de movimiento")]
    public float velocidadMovimiento = 2f;

    [Header("Objeto que debe estar activo")]
    public GameObject objetoRequerido;

    [Header("Objetos a activar cuando llegue al destino")]
    public GameObject objetoAActivar;
    public GameObject objetoAActivar2;

    [Header("Delay antes de activar (segundos)")]
    public float delayActivacion = 1f;

    private bool moverObjetos = false;
    private bool llegando = false;

    private void OnMouseDown()
    {
        if (objetoRequerido == null || !objetoRequerido.activeInHierarchy)
            return;

        // Mover primer objeto instantáneamente
        if (objetoAMover != null)
        {
            objetoAMover.position = posicionDestino;
        }

        // Iniciar movimiento de los otros objetos
        moverObjetos = true;
        llegando = false;
    }

    private void Update()
    {
        if (!moverObjetos)
            return;

        bool segundoLlegado = true;
        bool terceroLlegado = true;

        // Mover segundo objeto
        if (segundoObjeto != null)
        {
            Vector3 pos = segundoObjeto.position;

            float nuevaX = Mathf.MoveTowards(
                pos.x,
                posicionXDestino,
                velocidadMovimiento * Time.deltaTime
            );

            segundoObjeto.position = new Vector3(
                nuevaX,
                pos.y,
                pos.z
            );

            segundoLlegado = Mathf.Abs(nuevaX - posicionXDestino) < 0.01f;
        }

        // Mover tercer objeto
        if (tercerObjeto != null)
        {
            Vector3 pos = tercerObjeto.position;

            float nuevaX = Mathf.MoveTowards(
                pos.x,
                posicionXDestinoTercerObjeto,
                velocidadMovimiento * Time.deltaTime
            );

            tercerObjeto.position = new Vector3(
                nuevaX,
                pos.y,
                pos.z
            );

            terceroLlegado = Mathf.Abs(nuevaX - posicionXDestinoTercerObjeto) < 0.01f;
        }

        // Cuando ambos lleguen al destino
        if (!llegando && segundoLlegado && terceroLlegado)
        {
            llegando = true;
            moverObjetos = false;

            StartCoroutine(ActivarConDelay());
        }
    }

    private IEnumerator ActivarConDelay()
    {
        yield return new WaitForSeconds(delayActivacion);

        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }

        if (objetoAActivar2 != null)
        {
            objetoAActivar2.SetActive(true);
        }
    }
}