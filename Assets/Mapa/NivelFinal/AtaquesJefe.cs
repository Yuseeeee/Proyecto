using UnityEngine;

public class AtaquesJefe : MonoBehaviour
{
    public Animator anim;
    public Transform player;

    public float rangoAtaque = 1.8f;
    public int danio = 20;
    public float tiempoEntreGolpes = 0.7f;
    float proximoGolpe = 0f;

    void Update()
    {
        if (Time.time < proximoGolpe) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= rangoAtaque)
        {
            anim.SetTrigger("Attack");
            proximoGolpe = Time.time + tiempoEntreGolpes;
        }
    }

    public void GolpeEvent()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= rangoAtaque)
        {
            VidaPersonaje vp = player.GetComponent<VidaPersonaje>();
            if (vp != null)
                vp.RecibirDanio(danio);
        }
    }
}
