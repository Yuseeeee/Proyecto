using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesJugador : MonoBehaviour
{    
    public Animator animator;
    public Transform puntoDeAtaque;
    public LayerMask capasEnemigas; 

    public float p = 1f;
    public int danioPunio = 25;
    public float coolPunio = 0.3f;

    public float rangoBarrida = 2f;
    public float anguloBarrida = 90f;
    public int danioBarrida = 15;
    public float coolBarrida = 0.6f;

    public float rangoEspecial = 2.5f;
    public int danioEspecial = 40;
    public float knockbackFuerza = 6f;
    public float duracionAturdimiento = 0.8f;

    float proxPunio = 0f;
    float proxBarrida = 0f;
    public int cargaPorMuerte = 1;
    public int cargaNecesaria = 5;
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

        if (Input.GetKeyDown(KeyCode.C) && Time.time >= proxBarrida)
        {
            Barrida();
            proxBarrida = Time.time + coolBarrida;
        }

        if (Input.GetKeyDown(KeyCode.V) && especialListo)
        {
            LanzarEspecial();
            cargaActual = 0;
            especialListo = false;
        }
    }

    void Punetazo()
    {
        if (animator) animator.SetTrigger("GolpeMano");
        Collider[] hits = Physics.OverlapSphere(puntoDeAtaque.position, p, capasEnemigas);
        if (hits.Length == 0) return;
        Collider masCercano = null;
        float minDist = float.MaxValue;
        foreach (Collider c in hits)//Preguntar
        {
            float d = Vector3.Distance(transform.position, c.transform.position);//Preguntar
            if (d < minDist)
            {
                minDist = d;
                masCercano = c;
            }
        }
        if (masCercano != null)
        {
            VidaEnemigos ve = masCercano.GetComponent<VidaEnemigos>();//Preguntar
            if (ve != null) ve.RecibirDanio(danioPunio);
        }
    }
     
    void Barrida()
    {
        if (animator) animator.SetTrigger("Barrida");
        Collider[] hits = Physics.OverlapSphere(puntoDeAtaque.position, rangoBarrida, capasEnemigas);
        Vector3 forward = transform.forward;
        foreach (Collider c in hits)
        {
            Vector3 dir = (c.transform.position - puntoDeAtaque.position).normalized;
            float ang = Vector3.Angle(forward, dir);
            if (ang <= anguloBarrida * 0.5f)//Preguntar
            {
                VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
                if (ve != null) ve.RecibirDanio(danioBarrida);
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
        Collider[] hits = Physics.OverlapSphere(puntoDeAtaque.position, rangoEspecial, capasEnemigas);
        Vector3 forward = transform.forward;
        foreach (Collider c in hits)
        {
            Vector3 dir = (c.transform.position - puntoDeAtaque.position).normalized;
            float ang = Vector3.Angle(forward, dir);
            if (ang <= 100f * 0.5f)
            {
                VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
                if (ve != null)
                {
                    ve.RecibirDanio(danioEspecial);
                    Vector3 fuerzaVector = (c.transform.position - transform.position).normalized * knockbackFuerza + Vector3.up * (knockbackFuerza * 0.4f);
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
        if (puntoDeAtaque == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, p);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, rangoBarrida);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, rangoEspecial);
    }
}
