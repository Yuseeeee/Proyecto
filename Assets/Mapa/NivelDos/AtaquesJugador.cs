using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesJugador : MonoBehaviour
{
    public Transform puntoDeAtaque;
    public float rangoDeAtaque = 0.8f; 
    public LayerMask capasEnemigas; 
    public int danio = 25;

    private bool atacando = false;
    private float cooldownAtaque = 0.2f; 
    private float proximoAtaque = 0f;

    // public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && Time.time > proximoAtaque)
        {
            Atacar();
            proximoAtaque = Time.time + cooldownAtaque;
        }
    }

    void Atacar()
    {
        Debug.Log("¡Ataque!");
        // animator.SetTrigger("Atacar");

        
        // 1. Cosa invisible en el 'puntoDeAtaque'.
        Collider[] enemigosGolpeados = Physics.OverlapSphere(puntoDeAtaque.position, rangoDeAtaque, capasEnemigas);

        foreach(Collider enemigo in enemigosGolpeados)
        {
            Debug.Log("¡Hemos golpeado a " + enemigo.name + "!");

            VidaEnemigos vidaDelEnemigo = enemigo.GetComponent<VidaEnemigos>();
            if (vidaDelEnemigo != null)
            {
                vidaDelEnemigo.RecibirDanio(danio);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoDeAtaque == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, rangoDeAtaque);
    }
}