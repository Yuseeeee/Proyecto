using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }

    void Update()
    {
        scoreText.text = "Puntos: " + ScoreManager.Instance.score;
    }
}
