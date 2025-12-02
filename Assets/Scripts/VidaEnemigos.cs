using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        Debug.Log("Daño enemigo a: " + gameObject.name);

        if (vidaActual <= 0)
            Morir();
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
