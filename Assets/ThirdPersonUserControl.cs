using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // Referencia al ThirdPersonCharacter
        private Transform m_Cam;                  // Referencia a la cámara
        private Vector3 m_CamForward;             // Dirección actual de la cámara
        private Vector3 m_Move;                   // Vector de movimiento deseado
        private bool m_Jump;                      
        
        private void Start()
        {
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            }

            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update se llama en sincronización con la física
        private void FixedUpdate()
        {
            // Lectura de inputs Horizontal y Vertical (A/D y W/S)
            float h = CrossPlatformInputManager.GetAxis("Horizontal"); // A y D
            float v = CrossPlatformInputManager.GetAxis("Vertical"); // W y S
            bool crouch = Input.GetKey(KeyCode.C);

            // Calcula el vector de movimiento (dirección)
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
            // ----------------------------------------------------
            // LÓGICA DE VELOCIDAD (W = Caminar, Shift = Correr)
            // ----------------------------------------------------
            
            // Usamos v > 0.1f para asegurarnos de que el input hacia adelante (W) está activo
            if (v > 0.1f && Input.GetKey(KeyCode.LeftShift))
            {
                // Correr (2.5f es un valor común, ajústalo según tu ThirdPersonCharacter)
                m_Character.SetMoveSpeedMultiplier(2.5f); 
            }
            else
            {
                // Velocidad base para Caminar (1.5f es un valor común, ajústalo)
                m_Character.SetMoveSpeedMultiplier(1.5f);
            }
            // NOTA: Si no estás usando W, pero usas A/D/S, el personaje seguirá moviéndose a velocidad de caminar (1.5f).
        #endif

            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }

        // FUNCIÓN PÚBLICA CRUCIAL: Resetea el vector de movimiento al finalizar el ataque.
        public void ResetMoveVector()
        {
            // Soluciona el bug de "caminar solo" al reactivar el script de control.
            m_Move = Vector3.zero;
        }
    }
}