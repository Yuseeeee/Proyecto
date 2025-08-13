using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelCasa : MonoBehaviour
{
    public string nombreEscenaDestino; // Escena a la que lleva la casa
    public string nombreNivel;         // Ej: "Nivel 1"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            if (CambiarNivel.instancia != null)
            {
                CambiarNivel.instancia.MarcarNivelCompletado(nombreNivel);
            }

            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}