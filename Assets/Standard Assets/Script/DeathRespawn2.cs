using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathRespawn2 : MonoBehaviour
{
    public float limiteMuerte = -12;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limiteMuerte)
        {
            Debug.Log("Respawn");
            SceneManager.LoadScene("UIInteractionAreaYParkour");
        }
    }
}
