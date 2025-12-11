using UnityEngine;

public class Llave : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        AgarrarLlave inv = other.GetComponent<AgarrarLlave>();
        if (inv != null)
        {
            inv.RecogerLlave();
            Destroy(gameObject);
        }
    }
}
