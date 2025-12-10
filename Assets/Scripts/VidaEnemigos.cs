using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;
    public Animator anim;
    public int puntos = 10;

    bool muerto = false;

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
        if (muerto) return;

        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Morir();
            return;
        }

        anim.SetTrigger("Hit"); 
    }

    void Morir()
    {
        muerto = true;

        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null) agent.enabled = false;

        anim.SetTrigger("Dead");

        ScoreManager.Instance.AddPoints(puntos);
        GameManager.instance.EnemigoEliminado();

        Destroy(gameObject, 2f);
    }
}
