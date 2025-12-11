using UnityEngine;
using TMPro;
using System.Collections;

public class AgarrarLlave : MonoBehaviour
{
    public bool tieneLlave = false;
    public TMP_Text mensajeRecoger;
    public float duracionMensaje = 2f;
    Coroutine mensajeRutina;

    void Awake()
    {
        if (mensajeRecoger != null) mensajeRecoger.gameObject.SetActive(false);
    }

    public void RecogerLlave()
    {
        if (tieneLlave) return;
        tieneLlave = true;
        if (mensajeRutina != null) StopCoroutine(mensajeRutina);
        mensajeRutina = StartCoroutine(MostrarMensaje("Has recogido la llave"));
    }

    IEnumerator MostrarMensaje(string texto)
    {
        if (mensajeRecoger == null) yield break;
        mensajeRecoger.text = texto;
        mensajeRecoger.gameObject.SetActive(true);
        yield return new WaitForSeconds(duracionMensaje);
        mensajeRecoger.gameObject.SetActive(false);
        mensajeRutina = null;
    }
}
