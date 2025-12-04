using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int enemigosVivos = 0;
    public string mapaSig = "";
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void RegistrarEnemigo()
    {
        enemigosVivos++;
    }

    public void EnemigoEliminado()
    {
        enemigosVivos--;

        if (enemigosVivos <= 0)
            SceneManager.LoadScene(mapaSig);
    }
}
