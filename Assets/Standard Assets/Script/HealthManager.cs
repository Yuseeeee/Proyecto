using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int healthPoints;
    public int maxPS= 100;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        healthPoints = maxPS;

    }
    public void TakeDamage(int damagePoints)
    {
        if(healthPoints <= damagePoints)
        {
            return;
        }
        healthPoints -= damagePoints;
        uiManager.Updatehealth(healthPoints);
    }
}
