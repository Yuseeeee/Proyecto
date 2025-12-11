using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 puntoRespawn = new Vector3(0, 2, 0);
    public float alturaLimite = -10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void Update()
    {
        if (transform.position.y < alturaLimite)
        {
            Respawnear();
        }
    }

    void Respawnear()
    {
        transform.position = puntoRespawn;

        if (rb != null)  
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
