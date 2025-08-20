using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelCasa : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "SimpleFPSController")
        {
            Debug.Log("Cargando escena...");

            string nombreDelCubo = gameObject.name;
            
            switch (nombreDelCubo)
            {
                case "cubo azul": 
                    SceneManager.LoadScene("NivelTres");
                    break;

                case "cubo rojo": 
                    SceneManager.LoadScene("NivelDos");
                    break;
                
                case "cubo amarillo": 
                    SceneManager.LoadScene("NivelUno");
                    break;

                case "cubo verde": 
                    SceneManager.LoadScene("NivelCuatro");
                    break;
            }
        }
    }
}