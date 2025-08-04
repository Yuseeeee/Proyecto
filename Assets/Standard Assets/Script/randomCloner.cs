using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCloner : MonoBehaviour
{
    public int randomNumber;
    public int max;
    public int min;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClonRandom()
    {
        randomNumber = Random.Range(min, max + 1);
        GameObject clone = prefab1;
        if (randomNumber == 0)
        {
            clone = prefab1;
        } else if (randomNumber == 1)
        {
            clone = prefab2;
        } else if (randomNumber == 2)
        {
            clone = prefab3;
        }
        Instantiate(clone);
    }
}
