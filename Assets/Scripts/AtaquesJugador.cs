using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AtaquesJugador : MonoBehaviour
{
    public Animator animator;

    private ThirdPersonUserControl controlMovimiento;
    private ThirdPersonCharacter character;
    private bool isAttacking = false;
    public Transform puntoPunio;
    public Transform puntoPatada;
    public LayerMask capasEnemigas;
    public float rangoPunio = 1f;
    public float rangoPatada = 1.5f;
    int danioPunio;
    int danioPatada;
    public float duracionAnimacionPunio = 0.4f;
    public float duracionAnimacionPatada = 0.6f;
    public int baseDanioPunio = 75;   
    public int baseDanioPatada = 80;
    void Start()
    {
        controlMovimiento = GetComponent<ThirdPersonUserControl>();
        character = GetComponent<ThirdPersonCharacter>();
        danioPunio = baseDanioPunio + UpdateManager.Instance.extraDanioPunio;
        danioPatada = baseDanioPatada + UpdateManager.Instance.extraDanioPatada;
    }

    void Update()
    {
        if (isAttacking) return;

        if (Input.GetKeyDown(KeyCode.X))
            Punetazo();

        if (Input.GetKeyDown(KeyCode.Z))
            Patada();
    }

    void Punetazo()
    {
        isAttacking = true;
        controlMovimiento.bloqueado = true;

        animator.SetTrigger("GolpeMano");

        Invoke(nameof(EndAttack), duracionAnimacionPunio);
    }

    void Patada()
    {
        isAttacking = true;
        controlMovimiento.bloqueado = true;

        animator.SetTrigger("Patada");

        Invoke(nameof(EndAttack), duracionAnimacionPatada);
    }

    public void GolpeEvent()
    {
        AplicarDanio(puntoPunio, rangoPunio, danioPunio);
    }

    public void PatadaEvent()
    {
        AplicarDanio(puntoPatada, rangoPatada, danioPatada);
    }

    void AplicarDanio(Transform punto, float rango, int danio)
    {
        Debug.Log("Chequeando OverlapSphere en: " + punto.name);

        Collider[] hits = Physics.OverlapSphere(punto.position, rango, capasEnemigas);
        Debug.Log("Detectados: " + hits.Length);

        foreach (Collider c in hits)
        {
            Debug.Log("Collider encontrado: " + c.name);

            VidaEnemigos ve = c.GetComponent<VidaEnemigos>();
            if (ve != null)
            {
                ve.RecibirDanio(danio);
                return;
            }

            VidaJefe vj = c.GetComponent<VidaJefe>();
            if (vj != null)
            {
                vj.RecibirDanio(danio);
                return;
            }


            if (ve != null)
            {
                Debug.Log("Daño enemigo!");
                ve.RecibirDanio(danio);
            }
        }
    }

    void EndAttack()
    {
        controlMovimiento.HardResetInputs();
        character.ResetMotionValues();

        controlMovimiento.bloqueado = false;
        isAttacking = false;
    }
    public void MejorarPunio(int cantidad)
    {
        UpdateManager.Instance.AddPunio(cantidad);
        danioPunio += cantidad;
        Debug.Log("Mejoraste el puño +" + cantidad);
    }

    public void MejorarPatada(int cantidad)
    { 
        UpdateManager.Instance.AddPatada(cantidad);  
        danioPatada += cantidad;
        Debug.Log("Mejoraste la patada +" + cantidad);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (puntoPunio != null)
            Gizmos.DrawWireSphere(puntoPunio.position, rangoPunio);

        Gizmos.color = Color.blue;
        if (puntoPatada != null)
            Gizmos.DrawWireSphere(puntoPatada.position, rangoPatada);
    }
}
