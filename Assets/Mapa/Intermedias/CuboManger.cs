using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboManger : MonoBehaviour
{
   public static CuboManger instance;

    public List<string> cubosTocados = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegistrarCuboTocado(string nombreCubo)
    {
        if (!cubosTocados.Contains(nombreCubo))
            cubosTocados.Add(nombreCubo);
    }

    public bool EstaTocado(string nombreCubo)
    {
        return cubosTocados.Contains(nombreCubo);
    }
}
