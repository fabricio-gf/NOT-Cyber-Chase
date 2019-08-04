using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Vector3[] spawnPositions;

    public List<Transform> tiles = new List<Transform>();
    public List<Tile> spawnTiles = new List<Tile>();

    public GameObject[] playerPrefabs;

    public Transform playerParent;

    public Transform gridSpawner;

    GameObject obj;

    public GameObject[] SpawnPlayers(bool[] connectedPlayers)
    {
        foreach (Transform child in gridSpawner)
        {
            tiles.Add(child);
        }
        spawnTiles.Add(tiles[21].GetComponent<Tile>());
        spawnTiles.Add(tiles[23].GetComponent<Tile>());
        spawnTiles.Add(tiles[2].GetComponent<Tile>());
        spawnTiles.Add(tiles[6].GetComponent<Tile>());

        GameObject[] refs = new GameObject[4];

        for(int i = 0; i < connectedPlayers.Length; i++)
        {
            if (connectedPlayers[i])
            {
                obj = Instantiate(playerPrefabs[i], spawnPositions[i], Quaternion.identity, playerParent);
                obj.GetComponent<SlideMovimentation>().ActualTile = spawnTiles[i];
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
