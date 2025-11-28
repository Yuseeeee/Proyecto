using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    public float turnSpeed = 360f;
    public float moveSpeed = 2f;
    float m_ForwardAmount;
    float m_TurnAmount;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
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

    public void Move(Vector3 move)
    {
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

        UpdateAnimator();
    }

    void ApplyRotation()
    {
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    void UpdateAnimator()
    {
        bool isRunning =
            Input.GetKey(KeyCode.LeftShift) && m_ForwardAmount > 0.1f;

        m_Animator.SetBool("IsRunning", isRunning);
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
    }

    public void ResetMotionValues()
    {
        m_ForwardAmount = 0f;
        m_TurnAmount = 0f;
    }
}
