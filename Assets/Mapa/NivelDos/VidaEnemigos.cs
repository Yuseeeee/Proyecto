using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int Hp = 100;
    public int vidaActual;
    public int danioGolpe;
    public animator anim;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;

   
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Colllider other)
    {
        if(other.GameObject.Tag == "Golpe")
        {
            if (anim != null)
            {
                anim.play ("Enemigo1")
            }
        }
    }
}
