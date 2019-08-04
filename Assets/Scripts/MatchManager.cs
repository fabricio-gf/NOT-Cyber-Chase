using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager instance = null;

    public bool[] connectedPlayers;

    public PlayerSpawner playerSpawner;

    public GameObject[] playerReferences;

    public EnemySpawner enemySpawner;
    public GUIManager guiManager;
    public Countdown countdownScript;

    public delegate void MatchManagerDelegate();
    public MatchManagerDelegate OnGameStart;

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

        for(int i = 0; i < 4; i++)
        {
            if(InputManager.GetPlayerInput(i) != null)
            {
                connectedPlayers[i] = true;
            }
        }
    }

    private void Start()
    {
        playerReferences = playerSpawner.SpawnPlayers(connectedPlayers);
        guiManager.ActivatePlayerInfos(connectedPlayers);
        GameOver.instance.SetInitialLives(connectedPlayers);

        OnGameStart += StartMatch;
        countdownScript.StartCountdown();
    }

    public void StartMatch()
    {
        OnGameStart -= StartMatch;
        enemySpawner.canSpawn = true;

        for(int i = 0; i < playerReferences.Length; i++)
        {
            
            if (playerReferences[i] != null)
            {
                playerReferences[i].GetComponent<SlideMovimentation>().canMove = true;
                playerReferences[i].GetComponent<AutoShoot>().canShoot = true;
            }
        }
    }
}
