using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesJugador : MonoBehaviour
{    
    public Animator animator;

    public Transform puntoPunio;
    public Transform puntoPatada;
    public Transform puntoEspecial;

    public LayerMask capasEnemigas; 

    public float rangoPunio = 1f;
    public int danioPunio = 25;
    public float coolPunio = 0.3f;

    public float rangoPatada = 1.5f;
    public int danioPatada = 20;
    public float coolPatada = 0.5f;

    public float rangoEspecial = 2.5f;
    public int danioEspecial = 40;
    public float knockbackFuerza = 6f;
    public float duracionAturdimiento = 0.8f;

    public int cargaPorMuerte = 1;
    public int cargaNecesaria = 5;

    float proxPunio = 0f;
    float proxPatada = 0f;
    float proxEspecial = 0f;

    int cargaActual = 0;
    bool especialListo = false;

    void Start()
    {
        VidaEnemigos.OnEnemigoMuerto += CargarEspecial;
    }

    void OnDestroy()
    {
        VidaEnemigos.OnEnemigoMuerto -= CargarEspecial;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= proxPunio)
        {
            Punetazo();
            proxPunio = Time.time + coolPunio;
        }

        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= proxPatada)
        {
            Patada();
            proxPatada = Time.time + coolPatada;
        }

        if (Input.GetKeyDown(KeyCode.C) && especialListo)
        {
            LanzarEspecial();
            cargaActual = 0;
            especialListo = false;
        }
    }

    void Punetazo()
    {
        if (animator) animator.SetTrigger("GolpeMano");

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
            transform.forward = new Vector3(dir.x, 0, dir.z); // gira hacia el enemigo
            VidaEnemigos ve = masCercano.GetComponent<VidaEnemigos>();
            if (ve != null) ve.RecibirDanio(danioPunio);
        }
    }

    void Patada()
    {
        if (animator) animator.SetTrigger("Patada");

        Collider[] hits = Physics.OverlapSphere(puntoPatada.position, rangoPatada, capasEnemigas);
        foreach (Collider c in hits)
        {
            Vector3 dir = (c.transform.position - transform.position).normalized;
            float ang = Vector3.Angle(transform.forward, dir);
            if (ang <= 90f * 0.5f) // sólo enemigos frente al jugador
            {
                VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
                if (ve != null) ve.RecibirDanio(danioPatada);
            }
        }
    }

    void LanzarEspecial()
    {
        if (animator)
        {
            animator.ResetTrigger("EspecialCarga");
            animator.SetTrigger("EspecialLanzar");
        }

        Collider[] hits = Physics.OverlapSphere(puntoEspecial.position, rangoEspecial, capasEnemigas);
        foreach (Collider c in hits)
        {
            Vector3 dir = (c.transform.position - puntoEspecial.position).normalized;
            float ang = Vector3.Angle(transform.forward, dir);
            if (ang <= 100f * 0.5f)
            {
                VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
                if (ve != null)
                {
                    ve.RecibirDanio(danioEspecial);
                    Vector3 fuerzaVector = dir * knockbackFuerza + Vector3.up * (knockbackFuerza * 0.4f);
                    ve.ApplyKnockback(fuerzaVector, duracionAturdimiento);
                }
            }
        }
    }

    void CargarEspecial()
    {
        cargaActual += cargaPorMuerte;
        if (cargaActual >= cargaNecesaria)
        {
            cargaActual = cargaNecesaria;
            especialListo = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (puntoPunio != null) Gizmos.DrawWireSphere(puntoPunio.position, rangoPunio);

        Gizmos.color = Color.green;
        if (puntoPatada != null) Gizmos.DrawWireSphere(puntoPatada.position, rangoPatada);

        Gizmos.color = Color.blue;
        if (puntoEspecial != null) Gizmos.DrawWireSphere(puntoEspecial.position, rangoEspecial);
    }
}
