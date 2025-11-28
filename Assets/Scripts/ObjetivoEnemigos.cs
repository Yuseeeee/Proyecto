using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ObjetivoEnemigos : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] public Transform player;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInParent<Animator>();

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        anim.SetFloat("Speed", agent.velocity.magnitude);

    }
}