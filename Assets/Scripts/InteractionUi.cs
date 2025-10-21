using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject avisoUI;   
    public KeyCode teclaInteraction = KeyCode.E;
    private bool enRango = false;

    void Start()
    {
        avisoUI.SetActive(false);
    }

    void Update()
    {
        if (enRango)
        {
            avisoUI.SetActive(true);

            if (Input.GetKeyDown(teclaInteraction))
            {
                Debug.Log("Interaccion");
            }
        }
        else
        {
            avisoUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = false;
        }
    }
}
