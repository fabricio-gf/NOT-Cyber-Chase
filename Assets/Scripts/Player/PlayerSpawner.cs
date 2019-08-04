using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance = null;

    public Vector3[] spawnPositions;

    public List<Transform> tiles = new List<Transform>();
    public List<Tile> spawnTiles = new List<Tile>();

    public GameObject[] playerPrefabs;

    public Transform playerParent;

    public Transform gridSpawner;

    GameObject obj;

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

        for (int i = 0; i < connectedPlayers.Length; i++)
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

    public void RespawnPlayer(int index)
    {
        print("respawn request");
        StartCoroutine(RespawnDelay());
    }

    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < spawnTiles.Count; i++)
        {
            if (!spawnTiles[i].occupied)
            {
                obj = Instantiate(playerPrefabs[i], spawnPositions[i], Quaternion.identity, playerParent);
                obj.GetComponent<SlideMovimentation>().ActualTile = spawnTiles[i];
                obj.GetComponent<ToggleInvincibility>().Toggle();

                MatchManager.instance.playerReferences[i] = obj;
                break;
            }
        }
    }
}
