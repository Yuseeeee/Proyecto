using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelCasa : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("¡Trigger detectado! El objeto que entró es: " + other.gameObject.name);

        if (other.gameObject.name == "SimpleFPSController")
        {
            Debug.Log("¡Confirmado! Es el jugador. Cargando escena...");

            string nombreDelCubo = gameObject.name;
            
            switch (nombreDelCubo)
            {
                case "cubo azul": 
                    SceneManager.LoadScene("NivelUno");
                    break;

                case "cubo rojo": 
                    SceneManager.LoadScene("NivelDos");
                    break;
                
                case "cubo amarillo": 
                    SceneManager.LoadScene("NivelTres");
                    break;

                case "cubo verde": 
                    SceneManager.LoadScene("NivelCuatro");
                    break;
            }
        }
    }
}