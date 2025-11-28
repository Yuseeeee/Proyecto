using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AtaquesJugador : MonoBehaviour
{
    public Animator animator;

    private ThirdPersonUserControl controlMovimiento;
    private ThirdPersonCharacter character;
    private bool isAttacking = false;

    public float duracionAnimacionPunio = 0.4f;
    public float duracionAnimacionPatada = 0.6f;

    public Transform puntoPunio;
    public Transform puntoPatada;

    public LayerMask capasEnemigas;

    public float rangoPunio = 1f;
    public int danioPunio = 25;

    public float rangoPatada = 1.5f;
    public int danioPatada = 20;

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
        controlMovimiento.enabled = false;

        animator.SetFloat("Forward", 0f);
        animator.SetTrigger("GolpeMano");

        Invoke(nameof(EndAttack), duracionAnimacionPunio);
    }

    void Patada()
    {
        isAttacking = true;
        controlMovimiento.enabled = false;

        animator.SetFloat("Forward", 0f);
        animator.SetTrigger("Patada");

        Invoke(nameof(EndAttack), duracionAnimacionPatada);
    }

    void EndAttack()
    {
        controlMovimiento.HardResetInputs();
        character.ResetMotionValues();

        controlMovimiento.enabled = true;
        isAttacking = false;
    }
}
