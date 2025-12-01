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

public void GolpeEvent()
{
    Debug.Log("EVENTO DE GOLPE LLAMADO");
    AplicarDanio(puntoPunio, rangoPunio, danioPunio);
}
    void Patada()
    {
        isAttacking = true;
        controlMovimiento.bloqueado = true;

        animator.SetTrigger("Patada");

        AplicarDanio(puntoPatada, rangoPatada, danioPatada);

        Invoke(nameof(EndAttack), duracionAnimacionPatada);
    }

    void AplicarDanio(Transform punto, float rango, int danio)
{
    Debug.Log("Chequeo OverlapSphere");

    Collider[] hits = Physics.OverlapSphere(punto.position, rango, capasEnemigas);

    Debug.Log("Cantidad de colliders detectados: " + hits.Length);

    foreach (Collider c in hits)
    {
        Debug.Log("Detecté: " + c.name);

        VidaEnemigos ve = c.GetComponentInParent<VidaEnemigos>();
        if (ve != null)
        {
            Debug.Log("Daño enemigo");
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
    if (puntoPunio != null)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoPunio.position, rangoPunio);
    }

    if (puntoPatada != null)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(puntoPatada.position, rangoPatada);
    }
}

}
