using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static Update Instance;

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
        PlayerPrefs.Save();
        Debug.Log("Update: extraDanioPunio = " + extraDanioPunio);
    }

    public void AddPatada(int cantidad)
    {
        extraDanioPatada += cantidad;
        PlayerPrefs.Save();
        Debug.Log("Update: extraDanioPatada = " + extraDanioPatada);
    }
}
