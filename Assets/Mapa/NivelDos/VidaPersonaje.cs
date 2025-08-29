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
    }

    public void RecibirDaño(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        Debug.Log("Vida del jugador: " + vidaActual);

        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vidaActual / vidaMaxima;
        }

        if (vidaActual <= 0)
        {
            muerte();
        }
    }

    void muerte()
    {
        Debug.Log("El jugador ha muerto.");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}