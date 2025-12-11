using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character;
        private Transform m_Cam;
        private Vector3 m_CamForward;
        private Vector3 m_Move;

        public bool bloqueado = false;
        private bool jumpPressed = false;

        private void Start()
        {
            if (Camera.main != null)
                m_Cam = Camera.main.transform;

            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void Update()
        {
            jumpPressed = Input.GetKeyDown(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            if (bloqueado)
            {
                m_Character.Move(Vector3.zero, false);
                return;
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

            if (v > 0.1f && Input.GetKey(KeyCode.LeftShift))
                m_Character.SetMoveSpeedMultiplier(3f);
            else
                m_Character.SetMoveSpeedMultiplier(1.5f);

            m_Character.Move(m_Move, jumpPressed);
            jumpPressed = false;
        }

        public void HardResetInputs()
        {
            m_Move = Vector3.zero;

            Animator anim = GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetFloat("Forward", 0f);
                anim.SetFloat("Turn", 0f);
                anim.SetBool("IsRunning", false);
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = Vector3.zero;
        }
    }
}
