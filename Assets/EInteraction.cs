using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInteraction : MonoBehaviour
{
    public GameObject UIInteractionMessage;
    GameObject currentInteractable = null;

    private void Start()
    {
        UIInteractionMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Interactable")) return;

        UIInteractionMessage.SetActive(true);
        currentInteractable = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable")) return;

        UIInteractionMessage.SetActive(false);
        if (currentInteractable == other.gameObject)
            currentInteractable = null;
    }
}
