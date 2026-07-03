using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public List<Button> botones = new List<Button>();
    public KeyCode tecla = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            foreach (Button boton in botones)
            {
                if (boton != null)
                {
                    boton.onClick.Invoke();
                }
            }
        }
    }
}
