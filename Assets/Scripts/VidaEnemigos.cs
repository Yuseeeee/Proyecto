using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    public Animator anim;          

    void Awake()
    {
        anim = GetComponentInChildren<Animator>(); 
    }

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        anim.SetTrigger("Hit");

        if (vidaActual <= 0)
            Morir();
    }

    void Morir()
    {
        Destroy(gameObject);
    }

    public void Golpeado()
    {
    }
}
