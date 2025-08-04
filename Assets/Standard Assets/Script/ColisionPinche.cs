using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColisionPinche : MonoBehaviour
{
    public HealthManager healthManager;
    public int damagePoints;
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Contacto con " + col.gameObject);
        if (col.gameObject.name == "Player")

        {
            healthManager.TakeDamage(damagePoints);

            Destroy(gameObject);
        }
    }

}
