using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPersonaje : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;
    public Image barraDeVida;

    void Start()
    {
        vidaActual = vidaMaxima;
        
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = 1f; 
        }
    }

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        Debug.Log("¡Daño RECIBIDO! Vida restante: " + vidaActual);

        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vidaActual / vidaMaxima;
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