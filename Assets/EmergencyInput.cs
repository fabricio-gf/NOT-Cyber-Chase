using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyInput : MonoBehaviour
{
    public static EmergencyInput instance = null;

    bool getInputs = false;

    public GameObject[] playerTokens;

    public GameObject[] arrows;

    public GameObject readyButton;

    public bool[] playerConnected = new bool[4];

    int connectedPlayers = 0;

    bool notThisScene = false;

    bool first = false;

    SlideMovimentation player;

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

        DontDestroyOnLoad(gameObject);
    }

    public void GetInputs() {
        getInputs = true;
    }

    public void ResetNotThisScene()
    {
        getInputs = true;
        notThisScene = false;
    }

    public void NotThisScene()
    {
        notThisScene = true;
    }

    public void ResetFirst()
    {
        first = false;
    }

    private void Update()
    {
        if (notThisScene)
        {
            if (!first)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<SlideMovimentation>();
                first = true;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                player.moveUp();

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                player.moveRight();

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                player.moveDown();

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                player.moveLeft();

            }

            return;
        }
        if (!getInputs) return;
        if (Input.GetKeyDown(KeyCode.W))
        {
            
                DisconnectPlayer(1);
                DisconnectPlayer(2);
                DisconnectPlayer(3);
            ConnectPlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
                DisconnectPlayer(0);
                DisconnectPlayer(2);
                DisconnectPlayer(3);
            
            ConnectPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
                DisconnectPlayer(0);
                DisconnectPlayer(1);
                DisconnectPlayer(3);
            
            ConnectPlayer(2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            
                DisconnectPlayer(1);
                DisconnectPlayer(2);
                DisconnectPlayer(0);
            
            ConnectPlayer(3);
        }
    }

    void ConnectPlayer(int index)
    {
        playerConnected[index] = true;
        connectedPlayers++;
        if (connectedPlayers > 0)
        {
            readyButton.SetActive(true);
        }

        arrows[index].SetActive(true);
        playerTokens[index].SetActive(true);
    }

    void DisconnectPlayer(int index)
    {
        playerConnected[index] = false;
        if (connectedPlayers >0) connectedPlayers--;
        if (connectedPlayers == 0)
        {
            readyButton.SetActive(false);
        }

        arrows[index].SetActive(false);
        playerTokens[index].SetActive(false);
    }
}
