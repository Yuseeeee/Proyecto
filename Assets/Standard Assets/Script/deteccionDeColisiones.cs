using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccionDeColisiones : MonoBehaviour
{
    public scoreManager scoreManager;
    public MercaderiaScript mercaderiaScript;
    void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();
        mercaderiaScript = GetComponent<MercaderiaScript>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            scoreManager.AddScore(mercaderiaScript.scorePoints);
        }
    }

}
