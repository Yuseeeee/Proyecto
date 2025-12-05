using UnityEngine;

public class CofreMejora : MonoBehaviour
{
    public Animator animator;
    public int puntosNecesarios = 50;
    public bool abierto = false;
    public EleccionMejora uiMejora;

    private void OnTriggerEnter(Collider other)
    {
        if (abierto) return;

        if (ScoreManager.Instance.score >= puntosNecesarios)
        {
            AtaquesJugador aj = other.GetComponent<AtaquesJugador>();
            if (aj != null)
            {
                abierto = true;

                ScoreManager.Instance.score -= puntosNecesarios;
                Debug.Log("Cofre abierto → Te desconté " + puntosNecesarios + " puntos.");

                if (animator != null)
                    animator.SetTrigger("Abrir");

                uiMejora.MostrarOpciones(aj);
            }
        }
        else
        {
            Debug.Log("Te faltan puntos para abrir este cofre.");
        }
    }
}
