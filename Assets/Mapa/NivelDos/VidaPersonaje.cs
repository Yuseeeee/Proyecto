using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPersonaje : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;
    public Slider sliderVida;

    void Start()
    {
        vidaActual = vidaMaxima;
        
         if (sliderVida != null)
        {
            sliderVida.maxValue = vidaMaxima;
            sliderVida.minValue = 0;
            sliderVida.value = vidaActual;
        }
    }
    

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        Debug.Log("¡Daño RECIBIDO! Vida restante: " + vidaActual);

        if (sliderVida != null)
        {
            sliderVida.value = vidaActual;
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}