using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    public Color colorVidaLlena = Color.white; 
    public Color colorVidaMedia = Color.yellow; 
    public Color colorVidaBaja = Color.red; 

    private Renderer rend; 
    void Start()
    {
        vidaActual = vidaMaxima;

        rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            rend.material.color = colorVidaLlena;
        }
    }
    
    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;

        ActualizarColor();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void ActualizarColor()
    {
        if (rend == null) return;
        float porcentajeDeVida = (float)vidaActual / vidaMaxima;

        if (porcentajeDeVida > 0.66f)
        {
            rend.material.color = colorVidaLlena;
        }
        else if (porcentajeDeVida > 0.33f)
        {
            rend.material.color = colorVidaMedia;
        }
        else
        {
            rend.material.color = colorVidaBaja;
        }
    }

    void Morir()
    {
        Destroy(gameObject); 
    }
}