using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoPersonaje : MonoBehaviour
{
    public float jumpForce = 7f;
    public Rigidbody rb;
    private bool enSuelo = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cada vez que toca el piso, puede saltar de nuevo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }
}
