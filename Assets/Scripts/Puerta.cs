using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class Puerta : MonoBehaviour
{
    public TMP_Text mensajeLlave;
    public float duracionMensaje = 2f;

    private bool mostrandoMensaje = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        AgarrarLlave inventario = other.GetComponent<AgarrarLlave>();

        if (inventario.tieneLlave)
        {
            SceneManager.LoadScene("Inicio");
        }
        else
        {
            if (!mostrandoMensaje)
                StartCoroutine(MostrarMensaje());
        }
    }

    private IEnumerator MostrarMensaje()
    {
        mostrandoMensaje = true;

        mensajeLlave.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracionMensaje);

        mensajeLlave.gameObject.SetActive(false);

        mostrandoMensaje = false;
    }
}
