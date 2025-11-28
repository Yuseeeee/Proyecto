using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson; 

public class AtaquesJugador : MonoBehaviour
{    
    public Animator animator;

    // --- Variables de Control de Movimiento ---
    private ThirdPersonUserControl controlMovimiento; 
    // Bandera crucial para bloquear cualquier input (movimiento o ataque)
    private bool isAttacking = false; 

    [Tooltip("Duración del clip de animación 'Punching' en segundos")]
    public float duracionAnimacionPunio = 0.4f; 
    [Tooltip("Duración del clip de animación 'Patada' en segundos")]
    public float duracionAnimacionPatada = 0.6f; 

    public Transform puntoPunio;
    public Transform puntoPatada;

    public LayerMask capasEnemigas; 

    public float rangoPunio = 1f;
    public int danioPunio = 25;
    public float coolPunio = 0.3f; 

    public float rangoPatada = 1.5f;
    public int danioPatada = 20;
    public float coolPatada = 0.5f;

    float proxPunio = 0f;
    float proxPatada = 0f;

    void Start()
    {
        controlMovimiento = GetComponent<ThirdPersonUserControl>();
    }

    void Update()
    {
        // 0. BLOQUEO: Si está atacando, ignoramos *todo* input.
        if (isAttacking)
            return;

        // Puñetazo
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= proxPunio)
        {
            Punetazo();
            proxPunio = Time.time + coolPunio;
        }

        // Patada
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= proxPatada)
        {
            Patada();
            proxPatada = Time.time + coolPatada;
        }
    }

    void Punetazo()
    {
        // 1. INICIO DEL BLOQUEO
        isAttacking = true; 

        // 2. Detener el movimiento y programar la reactivación
        if (controlMovimiento != null)
        {
            controlMovimiento.enabled = false;
            if (animator) animator.SetFloat("Forward", 0f); 
            
            // Programar la función que termina el ataque
            Invoke("EndAttack", duracionAnimacionPunio);
        }

        // 3. Disparar la animación
        if (animator) animator.SetTrigger("GolpeMano"); 

        // --- Lógica de Daño (Sin cambios) ---
        Collider[] hits = Physics.OverlapSphere(puntoPunio.position, rangoPunio, capasEnemigas);
        if (hits.Length == 0) return;

        Collider masCercano = null;
        float minDist = float.MaxValue;
        foreach (Collider c in hits)
        {
            float d = Vector3.Distance(transform.position, c.transform.position);
            if (d < minDist)
            {
                minDist = d;
                masCercano = c;
            }
        }

        if (masCercano != null)
        {
            Vector3 dir = (masCercano.transform.position - transform.position).normalized;
            transform.forward = new Vector3(dir.x, 0, dir.z);
            VidaEnemigos ve = masCercano.GetComponentInParent<VidaEnemigos>();
            if (ve != null) ve.RecibirDanio(danioPunio);
        }
    }

    void Patada()
    {
        // 1. INICIO DEL BLOQUEO
        isAttacking = true; 

        // 2. Detener el movimiento y programar la reactivación
        if (controlMovimiento != null)
        {
            controlMovimiento.enabled = false;
            if (animator) animator.SetFloat("Forward", 0f); 
            Invoke("EndAttack", duracionAnimacionPatada);
        }
        
        // 3. Disparar la animación
        if (animator) animator.SetTrigger("Patada"); 

        // --- Lógica de Daño (Sin cambios) ---
        Collider[] hits = Physics.OverlapSphere(puntoPatada.position, rangoPatada, capasEnemigas);
        foreach (Collider c in hits)
        {
            Vector3 dir = (c.transform.position - transform.position).normalized;
            float ang = Vector3.Angle(transform.forward, dir);
            if (ang <= 90f * 0.5f)
            {
                VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
                if (ve != null) ve.RecibirDanio(danioPatada);
            }
        }
    }

    // FUNCIÓN ÚNICA que se llama por Invoke para terminar el ataque
    void EndAttack()
    {
        // 1. LIMPIEZA CRUCIAL: Resetea el vector de movimiento interno m_Move
        if (controlMovimiento != null)
        {
            controlMovimiento.ResetMoveVector(); // <--- ¡La nueva función!
        }

        // 2. Reactivar el script de movimiento
        if (controlMovimiento != null)
        {
            controlMovimiento.enabled = true;
        }
        
        // 3. Quitar el bloqueo: Permite nuevos inputs en Update()
        isAttacking = false; 
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (puntoPunio != null) Gizmos.DrawWireSphere(puntoPunio.position, rangoPunio);

        Gizmos.color = Color.green;
        if (puntoPatada != null) Gizmos.DrawWireSphere(puntoPatada.position, rangoPatada);
    }
}