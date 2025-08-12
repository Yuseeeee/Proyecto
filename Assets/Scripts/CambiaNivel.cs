using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class cambiarNivel : MonoBehaviour
{
    public static cambiarNivel instancia;

    public string ultimoNivelCompletado = "";

    // Lista de misiones según el progreso
    public string[] misiones; 
    // Ejemplo en Inspector:
    // 0: "Andá a la casa azul para ir al próximo nivel"
    // 1: "Andá a la casa roja para ir al próximo nivel"
    // 2: "Andá a la casa verde para ir al próximo nivel"
    // 3: "Misión completada"

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Inicio")
        {
            TextMeshProUGUI textoUI = GameObject.Find("Instrucciones")?.GetComponent<TextMeshProUGUI>();
            if (textoUI != null)
            {
                int indice = ProgresoActual();
                if (indice >= 0 && indice < misiones.Length)
                {
                    textoUI.text = misiones[indice];
                }
            }
        }
    }

    public void MarcarNivelCompletado(string nombreNivel)
    {
        ultimoNivelCompletado = nombreNivel;
    }

    private int ProgresoActual()
    {
        if (ultimoNivelCompletado == "") return 0;
        if (ultimoNivelCompletado == "Nivel 1") return 1;
        if (ultimoNivelCompletado == "Nivel 2") return 2;
        if (ultimoNivelCompletado == "Nivel 3") return 3;
        return 0;
    }
}