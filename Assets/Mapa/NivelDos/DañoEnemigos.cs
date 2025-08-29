using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigos : MonoBehaviour
{
    public int danio = 20; 
    private float tiempoEntreAtaques = 1.0f; 
    private float proximoAtaque = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time > proximoAtaque)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Enemigo tocó al jugador. Haciendo daño.");
                
                VidaPersonaje vidaDelJugador = collision.gameObject.GetComponent<VidaPersonaje>();

                if (vidaDelJugador != null)
                {
                    vidaDelJugador.RecibirDaño(danio);
                }

                proximoAtaque = Time.time + tiempoEntreAtaques;
            }
        }
    }
}