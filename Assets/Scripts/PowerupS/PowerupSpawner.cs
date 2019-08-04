using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner instance = null;

    public GameObject[] powerUpPrefabs;
    public Transform spawnParent;

    public float baseSpawnRate;
    public float spawnIncrement;

    float spawnRate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void CheckPowerupSpawn(Vector3 position)
    {
        if(Random.value <= spawnRate)
        {
            Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], position, Quaternion.identity, spawnParent);
            spawnRate = baseSpawnRate;
        }
        else
        {
            spawnRate += spawnIncrement;
        }
    }
}
