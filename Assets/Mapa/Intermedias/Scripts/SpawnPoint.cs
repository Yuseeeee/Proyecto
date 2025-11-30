using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Personaje;
    public Transform PuntoDeSpawn;

    void Start()
    {
        Personaje.transform.position = PuntoDeSpawn.position;
        Personaje.transform.rotation = PuntoDeSpawn.rotation;
    }
}
