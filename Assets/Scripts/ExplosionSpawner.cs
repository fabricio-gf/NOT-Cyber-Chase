using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public static ExplosionSpawner instance = null;

    public GameObject explosionPrefab;

    public Transform explosionParent;

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

    public void SpawnExplosion(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity, explosionParent);
    }
}
