using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager Instance;
    public int extraDanioPunio = 0;
    public int extraDanioPatada = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            extraDanioPunio = PlayerPrefs.GetInt("extraDanioPunio", 0);
            extraDanioPatada = PlayerPrefs.GetInt("extraDanioPatada", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPunio(int cantidad)
{
    extraDanioPunio += cantidad;
    PlayerPrefs.SetInt("extraDanioPunio", extraDanioPunio);
    PlayerPrefs.Save();
}

public void AddPatada(int cantidad)
{
    extraDanioPatada += cantidad;
    PlayerPrefs.SetInt("extraDanioPatada", extraDanioPatada);
    PlayerPrefs.Save();
}

}
