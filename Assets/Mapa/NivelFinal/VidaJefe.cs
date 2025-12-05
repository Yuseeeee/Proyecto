using UnityEngine;
using UnityEngine.SceneManagement;
public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 300;
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
        anim.SetTrigger("Die");
        Destroy(gameObject, 2f);
        SceneManager.LoadScene("FelicitacionJefe");

    }
}
