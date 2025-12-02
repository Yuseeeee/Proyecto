using UnityEngine;
using UnityEngine.AI;

public class ObjetivoEnemigos : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator anim;

    public float rangoDeteccion = 10f;
    public float rangoAtaque = 1.5f;
    public float rangoPerdida = 15f;

    public Transform[] puntosPatrulla;
    int indicePatrulla = 0;

    bool persiguiendo = false;
    bool atacando = false;

    public float tiempoEntreAtaques = 7f;
    float tiempoActual = 0f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        if (puntosPatrulla.Length > 0)
            agent.SetDestination(puntosPatrulla[indicePatrulla].position);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        tiempoActual += Time.deltaTime;
        if (dist <= rangoAtaque)
        {
            if (tiempoActual >= tiempoEntreAtaques)
            {
                HacerAtaque();
                tiempoActual = 0f;
            }
            return;
        }
        else
        {
            FinAtaque();
        }

        if (!persiguiendo && dist <= rangoDeteccion)
            persiguiendo = true;

        if (persiguiendo && dist >= rangoPerdida)
        {
            persiguiendo = false;
            VolverAPatrullar();
        }

        if (persiguiendo)
            PerseguirJugador();
        else
            Patrullar();

        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    void HacerAtaque()
    {
        atacando = true;
        agent.isStopped = true;
        anim.SetTrigger("Attack");
        anim.SetFloat("Speed", 0f);
    }

    void FinAtaque()
    {
        if (!atacando) return;
        atacando = false;
        agent.isStopped = false;
    }

    void PerseguirJugador()
    {
        if (atacando) return;
        agent.SetDestination(player.position);
    }

    void Patrullar()
    {
        if (puntosPatrulla.Length == 0 || atacando) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            indicePatrulla = (indicePatrulla + 1) % puntosPatrulla.Length;
            agent.SetDestination(puntosPatrulla[indicePatrulla].position);
        }
    }

    void VolverAPatrullar()
    {
        if (puntosPatrulla.Length > 0)
            agent.SetDestination(puntosPatrulla[indicePatrulla].position);
    }
}
