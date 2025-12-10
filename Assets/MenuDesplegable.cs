using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDesplegable : MonoBehaviour
{
    public GameObject[] botones;
    private bool abierto = false;

    public void ToggleMenu()
    {
        abierto = !abierto;

        foreach (GameObject b in botones)
        {
            b.SetActive(abierto);
        }
    }
}
