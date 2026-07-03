using UnityEngine;
using System.Collections;
using TMPro;

public class TextMachine : MonoBehaviour
{
    [TextArea(3, 10)]
    public string mensaje;

    [Header("Texto")]
    public float tiempoAntesDeEmpezar = 2f;
    public float tiempoEntreLetras = 0.05f;

    [Header("Animación")]
    public Animator animator;
    public string nombreEstadoAnimacion;

    [HideInInspector] public bool escribiendo;
    [HideInInspector] public bool textoCompleto;

    private TextMeshProUGUI textoUI;
    private Coroutine coroutineActual;

    private void Awake()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        textoUI.text = "";

        escribiendo = false;
        textoCompleto = false;

        if (animator != null)
        {
            animator.Play(nombreEstadoAnimacion, 0, 0f);
            animator.Update(0f);
            animator.speed = 0f;
        }

        if (coroutineActual != null)
            StopCoroutine(coroutineActual);

        coroutineActual = StartCoroutine(EscribirTexto());
    }

    private IEnumerator EscribirTexto()
    {
        yield return new WaitForSeconds(tiempoAntesDeEmpezar);

        escribiendo = true;

        if (animator != null)
        {
            animator.speed = 1f;
            animator.Play(nombreEstadoAnimacion, 0, 0f);
        }

        foreach (char letra in mensaje)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }

        escribiendo = false;
        textoCompleto = true;

        if (animator != null)
        {
            AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);

            while (estado.IsName(nombreEstadoAnimacion) &&
                   estado.normalizedTime < 1f)
            {
                yield return null;
                estado = animator.GetCurrentAnimatorStateInfo(0);
            }

            animator.Play(nombreEstadoAnimacion, 0, 0f);
            animator.Update(0f);
            animator.speed = 0f;
        }
    }

    public void CompletarTextoInstantaneamente()
    {
        if (!escribiendo)
            return;

        if (coroutineActual != null)
            StopCoroutine(coroutineActual);

        textoUI.text = mensaje;

        escribiendo = false;
        textoCompleto = true;

        if (animator != null)
        {
            animator.Play(nombreEstadoAnimacion, 0, 0f);
            animator.Update(0f);
            animator.speed = 0f;
        }
    }
}