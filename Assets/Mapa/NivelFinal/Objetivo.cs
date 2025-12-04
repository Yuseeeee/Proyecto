using UnityEngine;
using UnityEngine.AI;

public class Objetivo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
