using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtVida;
    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "0" + " puntos";
        txtVida.text = "100 HP";
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString();
    }
    public void Updatehealth(int health)
    {
        txtVida.text = health.ToString();
    }
}
