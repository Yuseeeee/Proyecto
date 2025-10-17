using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VidaEnemigos : MonoBehaviour
{
    public static event Action OnEnemigoMuerto;
    public int vidaMaxima = 100;
    public int vidaActual;
    private Renderer auraRenderer; // El componente visual del aura.
    private float duracionFlash = 0.15f;
    private UnityEngine.AI.NavMeshAgent agent; //Preguntar
    private bool isStunned = false;
    private Rigidbody rb;
    void Start()
    {
        vidaActual = vidaMaxima;
        Transform auraTransform = transform.Find("AuraDeDano");
        if (auraTransform != null)
        {
            auraRenderer = auraTransform.GetComponent<Renderer>();
            auraRenderer.enabled = false; 
        }
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();

    }

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;
        if (auraRenderer != null) StartCoroutine(FlashAura());
        if (vidaActual <= 0) Morir();
    }

    IEnumerator FlashAura()
    {
        auraRenderer.enabled = true; 
        yield return new WaitForSeconds(duracionFlash);
        auraRenderer.enabled = false; 
    }

    void Morir()
    {
        OnEnemigoMuerto?.Invoke();
        Destroy(gameObject);
    }

    public void ApplyKnockback(Vector3 fuerza, float duracionStun)
    {
        if (isStunned) return;
        StartCoroutine(KnockbackCoroutine(fuerza, duracionStun));
    }

    IEnumerator KnockbackCoroutine(Vector3 fuerza, float duracion)
    {
        isStunned = true;
        if (agent != null) agent.enabled = false;
        else transform.position += fuerza * Time.deltaTime;
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(fuerza, ForceMode.VelocityChange);
        }
        yield return new WaitForSeconds(duracion);
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        if (agent != null) agent.enabled = true;
            isStunned = false;
    }
}