using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask Mask;
    public float distancia = 3;
    // Start is called before the first frame update
    void Start()
    {
        Mask = LayerMask.GetMask("Rayvast Detect");

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, Mask))
        {
            if(hit.collider.tag == "Objeto interactivo")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();
                }
            }
        }
    }
}
