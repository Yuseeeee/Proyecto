using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FuncionBoton : MonoBehaviour
{
    public Button boton; 
    public KeyCode tecla = KeyCode.M;
    public string NombreDeEscena;

    private void Start()
    {
        boton.onClick.AddListener(CargarEscena);
    }
    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            CargarEscena();
        }
    }
    void CargarEscena()
    {
        SceneManager.LoadScene(NombreDeEscena);
    }
}
