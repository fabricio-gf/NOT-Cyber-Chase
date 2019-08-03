using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3[] spawnPositions;
    public GameObject[] enemies;

    public Transform enemyParent;
    public float spawnRate;
    public float difficultyMultiplier;
    public bool canSpawn = false;

    float currentTime;
    int randomIndex;

    private void Start()
    {
        currentTime = spawnRate;
    }

    void Update()
    {
        if (canSpawn)
        {
            currentTime -= Time.deltaTime;

            if(currentTime <= 0)
            {
                randomIndex = Random.Range(0, enemies.Length);

                Instantiate(enemies[randomIndex], spawnPositions[Random.Range(0, spawnPositions.Length)], Quaternion.identity, enemyParent);
                currentTime += spawnRate;
            }
        }
    }

    public void TriggerSpawn(bool trigger)
    {
        canSpawn = trigger;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < spawnPositions.Length; i++) {
            Gizmos.DrawWireCube(spawnPositions[i], new Vector3(1, 1, 0));
        }
    }
}
