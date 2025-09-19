using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject objetoASpawnear;  // El prefab
    public Transform puntoDeSpawn;      // El lugar donde aparecerá

    void Start()
    {
        // Instancia el objeto en el punto de spawn
        Instantiate(objetoASpawnear, puntoDeSpawn.position, puntoDeSpawn.rotation);
    }
}
