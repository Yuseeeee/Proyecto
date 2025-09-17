using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    private Renderer auraRenderer; // El componente visual del aura.
    private float duracionFlash = 0.15f;

    void Start()
    {
        vidaActual = vidaMaxima;

        // Buscamos el objeto "AuraDeDano" entre los hijos.
        Transform auraTransform = transform.Find("AuraDeDano");
        if (auraTransform != null)
        {
            auraRenderer = auraTransform.GetComponent<Renderer>();
            auraRenderer.enabled = false; // Nos aseguramos de que empiece invisible.
        }
        else
        {
            Debug.LogError("¡ERROR! No se encontró el objeto hijo 'AuraDeDano' en " + gameObject.name);
        }
    }

    public void RecibirDanio(int cantidadDeDanio)
    {
        vidaActual -= cantidadDeDanio;

        // Si tenemos un aura, iniciamos el flash.
        if (auraRenderer != null)
        {
            StartCoroutine(FlashAura());
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Rutina que activa y desactiva el aura rápidamente.
    IEnumerator FlashAura()
    {
        auraRenderer.enabled = true; // La hace visible.
        yield return new WaitForSeconds(duracionFlash);
        auraRenderer.enabled = false; // La vuelve a ocultar.
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}