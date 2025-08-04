using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonador : MonoBehaviour
{
    public GameObject cuboAClonar;

    // Start is called before the first frame update
    void Start()
    {
        clonCubo();
    }

    public void clonCubo()
    {
        Instantiate(cuboAClonar);
    }
}
