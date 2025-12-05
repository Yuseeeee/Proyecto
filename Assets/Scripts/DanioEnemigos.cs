using UnityEngine;

public class DanioEnemigos : MonoBehaviour
{
    public Transform puntoAtaque;
    public float rangoAtaque = 1f;
    public int danio = 10;

    public Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Golpear()
    {
        Collider[] hits = Physics.OverlapSphere(puntoAtaque.position, rangoAtaque);

        foreach (Collider c in hits)
        {
            if (c.CompareTag("Player"))
            {
                VidaPersonaje vida = c.GetComponent<VidaPersonaje>();
                if (vida != null)
                {
                    vida.RecibirDanio(danio);
                }
            }
        }
    }

    public void DispararAnimAtaque()
    {
        anim.SetTrigger("Attack");
    }

    private void OnDrawGizmos()
    {
        if (puntoAtaque != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(puntoAtaque.position, rangoAtaque);
        }
    }
}
