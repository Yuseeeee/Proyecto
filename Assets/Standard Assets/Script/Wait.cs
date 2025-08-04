using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public float timeToWait;
    float timeElapsed;
    public Transform cuboTR;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(ElevateCube),0,timeToWait);
        StartCoroutine(WaitUntilElevate());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        //Debug.Log(timeElapsed += Time.deltaTime);
        //if (timeElapsed >= timeToWait)
        //{
        //    Debug.Log("Tiempo cumplido");
        //    ElevateCube();
        //    timeElapsed = 0;
        //}
        //else
        //{
        //    Debug.Log(timeElapsed += Time.deltaTime);
           
        //}
    }

    IEnumerator WaitUntilElevate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);//Hasta que no pase la linea no se hace la de abajo, se espera a que se cumpla
            ElevateCube();

        }
    }

    void ElevateCube()
    {
        cuboTR.position += Vector3.up * 2;
    }
}
