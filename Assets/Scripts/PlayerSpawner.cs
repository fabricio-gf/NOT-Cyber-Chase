using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Vector3[] spawnPositions;

    public GameObject[] playerPrefabs;

    public Transform playerParent;

    GameObject obj;

    public void SpawnPlayers(bool[] connectedPlayers)
    {
        for(int i = 0; i < connectedPlayers.Length; i++)
        {
            if (connectedPlayers[i])
            {
                obj = Instantiate(playerPrefabs[i], spawnPositions[i], Quaternion.identity, playerParent);
            }
        }
    }
}
