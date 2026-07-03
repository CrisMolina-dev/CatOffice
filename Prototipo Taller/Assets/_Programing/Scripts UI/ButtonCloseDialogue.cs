using UnityEngine;

public class ButtonCloseDialogue : MonoBehaviour
{
    public TextMachine textMachine;

    public GameObject[] objetosADesactivar;

    public void AlPresionarBoton()
    {
        // Si el texto aún se escribe, completarlo
        if (textMachine.escribiendo)
        {
            textMachine.CompletarTextoInstantaneamente();
            return;
        }

        // Si ya terminó, desactivar objetos
        if (textMachine.textoCompleto)
        {
            foreach (GameObject obj in objetosADesactivar)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
}