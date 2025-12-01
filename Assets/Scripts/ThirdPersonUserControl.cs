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

        // ahora es público para que AtaquesJugador lo pueda activar/desactivar
        public bool bloqueado = false;

        private void Start()
        {
            if (Camera.main != null)
                m_Cam = Camera.main.transform;

            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void FixedUpdate()
        {
            // BLOQUEO DE MOVIMIENTO
            if (bloqueado)
            {
                m_Move = Vector3.zero;
                m_Character.Move(Vector3.zero);
                return;
            }

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // Dirección según cámara
            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

            // Correr con Shift izquierdo
            if (v > 0.1f && Input.GetKey(KeyCode.LeftShift))
                m_Character.SetMoveSpeedMultiplier(2.5f);
            else
                m_Character.SetMoveSpeedMultiplier(1.5f);

            m_Character.Move(m_Move);
        }

        // Hard Reset para ataques
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
