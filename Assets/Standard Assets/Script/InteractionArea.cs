    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class InteractionArea : MonoBehaviour
    {
        public GameObject UIInteractionMessage;
        public bool canInteract;
        public MercaderiaScript mercaderia;
        public scoreManager scoreManager;
        public int points;
         void Start()
        {
            UIInteractionMessage.SetActive(false);
        }

         void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canInteract)
                {
                    Destroy(mercaderia.gameObject);
                scoreManager.AddScore(points);
                    EndInteraction();
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            mercaderia = other.GetComponent<MercaderiaScript>();
            if (mercaderia)
            {
                UIInteractionMessage.SetActive(true);
                canInteract = true;
            }

        }

        void OnTriggerExit(Collider other)
        {
            EndInteraction();

        }

        void EndInteraction()
        {
            mercaderia = null;
            canInteract = false;
            UIInteractionMessage.SetActive(false);
        }
    }

