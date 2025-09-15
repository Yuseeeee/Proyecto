using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour
{
      private int danio = 10; 
    
    private float tiempoEntreAtaques = 1.0f; 
    private float proximoAtaque = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time > proximoAtaque)
        {
            if (collision.gameObject.CompareTag("Jugador"))
            {
                VidaPersonaje vidaDelJugador = collision.gameObject.GetComponent<VidaPersonaje>();

                if (vidaDelJugador != null)
                {
                    vidaDelJugador.RecibirDanio(danio);
                }
                else
                {
                    Debug.LogError("El objeto '" + collision.gameObject.name + "' no tiene el script 'VidaPersonaje'.");
                }

                proximoAtaque = Time.time + tiempoEntreAtaques;
            }
        }
    }
}