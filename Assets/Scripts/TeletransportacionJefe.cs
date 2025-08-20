using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeletransportacionJefe : MonoBehaviour
{
    public float limite = -12;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limite)
        {
            Debug.Log("Teletransportando");
            SceneManager.LoadScene("NivelJefe");
        }
    }
}