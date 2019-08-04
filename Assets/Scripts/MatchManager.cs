using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public bool[] connectedPlayers;

    public PlayerSpawner playerSpawner;

    GameObject[] playerReferences;

    public EnemySpawner enemySpawner;
    public GUIManager guiManager;
    public Countdown countdownScript;

    public delegate void MatchManagerDelegate();
    public MatchManagerDelegate OnGameStart;

    private void Awake()
    {
        //get connected players
    }

    private void Start()
    {
        playerReferences = playerSpawner.SpawnPlayers(connectedPlayers);
        guiManager.ActivatePlayerInfos(connectedPlayers);

        OnGameStart += StartMatch;
        countdownScript.StartCountdown();
    }

    public void StartMatch()
    {
        OnGameStart -= StartMatch;
        enemySpawner.canSpawn = true;

        for(int i = 0; i < playerReferences.Length; i++)
        {
            //allow inputs
            if(playerReferences[i] != null)
                playerReferences[i].GetComponent<AutoShoot>().canShoot = true;
        }
    }
}
