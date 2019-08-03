using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public bool[] connectedPlayers;

    public PlayerSpawner playerSpawner;

    GameObject[] playerReferences;

    public EnemySpawner enemySpawner;
    public PointsTracker pointsTracker;

    private void Awake()
    {
        //get connected players
    }

    private void Start()
    {
        playerReferences = playerSpawner.SpawnPlayers(connectedPlayers);
    }

    public void StartCountdown()
    {
        //player spawn animation
        //toggle points trackers

        //start countdown

        //on end, match start
    }

    public void OnMatchStart()
    {
        //start enemy spawns
        //allow inputs
        //start auto shooting
    }
}
