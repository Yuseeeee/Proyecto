using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int Hp = 100;
    public int vidaActual;
    public int danioPuño;
    public int danioPatada;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = Hp;

   
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GameObject.Tag == "Puño")
        {
            if (anim != null)
            {
                anim.play ("GolpeEnemigo");
            }
            Hp -= danioGolpe;
        }
        if(other.GameObject.Tag == "Patada")
        {
            if (anim != null)
            {
                anim.play ("GolpeEnemigo");
            }
            Hp -= danioGolpe;
        }

        if (hp <= 0)
        {
            Destroy(GameObject);
        }
    }
}
