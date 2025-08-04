using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreManager : MonoBehaviour
{
    public int score;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
    }

   public void AddScore()
    {
        score++;
        uiManager.UpdateScore(score);
    }
    public void AddScore(int scorePoints)
    {
        score += scorePoints;
        uiManager.UpdateScore(score);
    }
}
