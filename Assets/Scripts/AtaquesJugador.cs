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
    public int danioPunio = 25;
    public int danioPatada = 20;
    public float duracionAnimacionPunio = 0.4f;
    public float duracionAnimacionPatada = 0.6f;

    void Start()
    {
        controlMovimiento = GetComponent<ThirdPersonUserControl>();
        character = GetComponent<ThirdPersonCharacter>();
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

            VidaEnemigos ve = c.transform.root.GetComponentInChildren<VidaEnemigos>();

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
