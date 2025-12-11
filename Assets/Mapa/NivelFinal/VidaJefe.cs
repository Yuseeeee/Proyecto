using UnityEngine;
using UnityEngine.SceneManagement;
public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 300;
    public int vidaActual;
    bool muerto = false;

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
        muerto = true;
        GetComponent<ObjetivoEnemigos>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false; 
        anim.SetTrigger("Dead");
        GameManager.instance.EnemigoEliminado();
        Destroy(gameObject, 2f);
        SceneManager.LoadScene("FelicitacionJefe");

    }
}
