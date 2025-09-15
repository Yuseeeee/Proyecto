using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

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
        Debug.Log(gameObject.name + " recibió daño. Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(gameObject.name + " ha sido derrotado.");
        
        Destroy(gameObject); 
    }
}