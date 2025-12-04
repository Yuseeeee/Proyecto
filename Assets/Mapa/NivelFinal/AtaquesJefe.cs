using UnityEngine;

public class AtaquesJefe : MonoBehaviour
{
    public Animator anim;
    public Transform player;

    public Transform puntoAtaque;
    public float rangoAtaque = 1.2f;
    public int danio = 20;

    public float tiempoEntreGolpes = 0.7f;
    float proximoGolpe = 0f;
    
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Time.time < proximoGolpe) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= rangoAtaque + 0.5f)
        {
            anim.SetTrigger("Attack");
            proximoGolpe = Time.time + tiempoEntreGolpes;
        }
    }

    public void GolpeEvent()
    {
        Collider[] hits = Physics.OverlapSphere(puntoAtaque.position, rangoAtaque);

        foreach (Collider c in hits)
        {
            if (c.gameObject == player.gameObject)
            {
                VidaPersonaje vp = player.GetComponent<VidaPersonaje>();
                if (vp != null) vp.RecibirDanio(danio);
            }
        }
    }
}
