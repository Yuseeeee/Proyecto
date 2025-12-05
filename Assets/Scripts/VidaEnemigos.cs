using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;
    public Animator anim;
    public int puntos = 10;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        vidaActual = vidaMaxima;
        GameManager.instance.RegistrarEnemigo();
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
        ScoreManager.Instance.AddPoints(puntos);
        GameManager.instance.EnemigoEliminado();
        Destroy(gameObject);
    }

    public void Golpeado()
    {
    }
}
