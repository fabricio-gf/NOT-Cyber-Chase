using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Vector3[] spawnPositions;

    public GameObject[] playerPrefabs;

    public Transform playerParent;

    GameObject obj;

    public GameObject[] SpawnPlayers(bool[] connectedPlayers)
    {
        GameObject[] refs = new GameObject[4];

        for(int i = 0; i < connectedPlayers.Length; i++)
        {
            if (connectedPlayers[i])
            {
                obj = Instantiate(playerPrefabs[i], spawnPositions[i], Quaternion.identity, playerParent);
                refs[i] = obj;
            }
        }

        return refs;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Gizmos.DrawWireCube(spawnPositions[i], new Vector3(1, 1, 0));
        }
    }
}
