using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public GameObject ControladorEscena;
    public void CambiarDeEscena(string Inicio)
    {
        SceneManager.LoadScene(Inicio);
    }
}
