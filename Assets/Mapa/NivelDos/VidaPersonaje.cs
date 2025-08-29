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

    void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        Debug.Log("¡Daño RECIBIDO! Vida restante: " + vidaActual);

        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vidaActual / vidaMaxima;
        }
        else
        {
            Debug.LogWarning("La barra de vida no está asignada en el Inspector.");
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