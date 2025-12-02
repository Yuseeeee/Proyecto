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
        Debug.Log("Daño enemigo (" + vidaActual + ")");

        if (vidaActual <= 0)
            Morir();
    }

    void Morir()
    {
        Debug.Log("Enemigo destruido");
        Destroy(gameObject);
    }
}
