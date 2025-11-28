using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour
{
    public int danio = 10; // daño por ataque
    public float tiempoEntreAtaques = 1.0f;
    private float proximoAtaque = 0f;
    public float rangoAtaque = 2.0f; // distancia a la que puede golpear
    public Transform puntoAtaque; // desde dónde dispara el raycast (opcional)
    public Transform player; // asignar el jugador en Inspector

    void Update()
    {
        if (Time.time < proximoAtaque) return;

        Vector3 origen = puntoAtaque != null ? puntoAtaque.position : transform.position;
        Vector3 direccion = (player.position - origen).normalized;


        RaycastHit hit;
        if (Physics.Raycast(origen, direccion, out hit, rangoAtaque))
        {
            if (hit.collider.CompareTag("Player"))
            {
                VidaPersonaje vidaDelJugador = hit.collider.GetComponent<VidaPersonaje>();
                if (vidaDelJugador != null)
                {
                    vidaDelJugador.RecibirDanio(danio);
                    Debug.Log("¡Jugador golpeado! Vida actual: " + vidaDelJugador.vidaActual);
                }

                proximoAtaque = Time.time + tiempoEntreAtaques;
            }
        }

        // Opcional: dibujar el raycast en Scene para debug
        Debug.DrawRay(origen, direccion * rangoAtaque, Color.red);
    }
}
