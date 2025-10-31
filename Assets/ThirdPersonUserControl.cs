using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // referencia al ThirdPersonCharacter
        private Transform m_Cam;                  // referencia a la cámara principal
        private Vector3 m_CamForward;             // dirección actual hacia adelante de la cámara
        private Vector3 m_Move;                   // dirección de movimiento
        private bool m_Jump;                      // salto

        private Rigidbody rb; // agregado: rigidbody para movimiento simple sin animaciones
        public float speed = 5f; // velocidad de movimiento

        private void Start()
        {
            // obtener cámara principal
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Warning: no main camera found. Se necesita una cámara con tag 'MainCamera'.", gameObject);
            }

            // obtener componente del personaje
            m_Character = GetComponent<ThirdPersonCharacter>();

            // agregado: obtener Rigidbody
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        private void FixedUpdate()
        {
            // leer inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calcular dirección de movimiento
            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

#if !MOBILE_INPUT
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f; // caminar más lento con shift
#endif

            // 🔻 COMENTADO: movimiento con animaciones (temporalmente desactivado)
            // m_Character.Move(m_Move, crouch, m_Jump);

            // 🔹 NUEVO: movimiento físico simple sin animaciones
            if (m_Move.magnitude > 0.1f)
            {
                Vector3 moveDir = m_Move.normalized * speed * Time.fixedDeltaTime;
                rb.MovePosition(transform.position + moveDir);

                // hacer que mire hacia donde se mueve
                transform.rotation = Quaternion.LookRotation(m_Move);
            }

            m_Jump = false;
        }
    }
}
