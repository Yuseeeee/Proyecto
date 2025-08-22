using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgenteCapsula : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public Transform objetivo;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objetivo.position;
    }
}