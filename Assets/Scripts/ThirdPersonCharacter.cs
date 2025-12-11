using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    public float turnSpeed = 360f;
    public float moveSpeed = 2f;
    public float jumpPower = 12f;
    public float gravityMultiplier = 2f;

    float m_ForwardAmount;
    float m_TurnAmount;
    Rigidbody m_Rigidbody;
    Animator m_Animator;

    bool isGrounded = true;
    float groundCheckDistance = 0.7f;

    float speedMultiplier = 1.3f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void SetMoveSpeedMultiplier(float s)
    {
        speedMultiplier = s;
    }

    public void Move(Vector3 move, bool jump)
    {
        CheckGroundStatus();

        if (move.magnitude > 1f)
            move.Normalize();

        move = transform.InverseTransformDirection(move);

        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        ApplyRotation();

        Vector3 velocity =
            transform.forward * (m_ForwardAmount * moveSpeed * speedMultiplier);
        velocity.y = m_Rigidbody.velocity.y;

        m_Rigidbody.velocity = velocity;

        if (jump && isGrounded)
            DoJump();

        ApplyExtraGravity();
        UpdateAnimator(jump);
    }

    void DoJump()
    {
        m_Rigidbody.velocity = new Vector3(
            m_Rigidbody.velocity.x,
            jumpPower,
            m_Rigidbody.velocity.z
        );

        isGrounded = false;
        m_Animator.SetTrigger("Jump");
    }

    void ApplyRotation()
    {
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    void ApplyExtraGravity()
    {
        if (!isGrounded)
        {
            Vector3 extraGravity = (Physics.gravity * gravityMultiplier) - Physics.gravity;
            m_Rigidbody.AddForce(extraGravity);
        }
    }

    void UpdateAnimator(bool jumpPressed)
    {
        bool isRunning =
            Input.GetKey(KeyCode.LeftShift) && m_ForwardAmount > 0.1f;

        m_Animator.SetBool("IsRunning", isRunning);
        m_Animator.SetBool("OnGround", isGrounded);
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
    }

    void CheckGroundStatus()
{
    Vector3 origen = transform.position + Vector3.up * 0.01f;
float distancia = groundCheckDistance + .5f;  


    Debug.DrawRay(origen, Vector3.down * distancia, Color.yellow);

    isGrounded = Physics.Raycast(origen, Vector3.down, distancia);
}

    

    public void ResetMotionValues()
    {
        m_ForwardAmount = 0f;
        m_TurnAmount = 0f;
    }
}
