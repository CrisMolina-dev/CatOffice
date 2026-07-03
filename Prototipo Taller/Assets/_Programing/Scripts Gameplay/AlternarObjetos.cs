using UnityEngine;

public class AlternarObjetos : MonoBehaviour
{
    [Header("Objetos a alternar")]
    public GameObject objetoA;
    public GameObject objetoB;

    [Header("Tiempo entre cambios")]
    public float intervalo = 0.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervalo)
        {
            Alternar();
            timer = 0f;
        }
    }

    void Alternar()
    {
        if (objetoA.activeSelf)
        {
            objetoA.SetActive(false);
            objetoB.SetActive(true);
        }
        else
        {
            objetoA.SetActive(true);
            objetoB.SetActive(false);
        }
    }
}