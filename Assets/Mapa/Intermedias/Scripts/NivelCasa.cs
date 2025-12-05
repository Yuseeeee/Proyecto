using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelCasa : MonoBehaviour
{
    public string nombreNivel; 

     private void Start()
    {
        if (CuboManger.instance != null && CuboManger.instance.EstaTocado(gameObject.name))
        {
            Destroy(gameObject);
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CuboManger.instance != null)
                CuboManger.instance.RegistrarCuboTocado(gameObject.name);

            Destroy(gameObject);

            SceneManager.LoadScene(nombreNivel);
        }
    }

}
