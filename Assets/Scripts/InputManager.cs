using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputType {
    None,
    Up,
    Right,
    Down,
    Left,
    Tap,
    DoubleTap,
    Confirmation,
    Cancel
}

public class InputManager : MonoBehaviour {

    public static InputManager instance = null;

    void Awake() {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //Destroy the fake
        else if (instance != this)
            Destroy(gameObject);

        //Dont destroy the ruler
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    static PlayerController Player0;
    static PlayerController Player1;
    static PlayerController Player2;
    static PlayerController Player3;

    static bool inlobby = true;

    public GameObject[] playerTokens;

    public GameObject[] arrows;

    public GameObject readyButton;

    int connectedPlayers = 0;

    void Start() {

    }
    

    public void ConnectPlayer(int index, PlayerController controller)
    {
        connectedPlayers++;
        if (connectedPlayers > 0)
        {
            readyButton.SetActive(true);
        }
        switch (index)
        {
            case 0:
                Player0 = controller;
                break;
            case 1:
                Player1 = controller;
                break;
            case 2:
                Player2 = controller;
                break;
            case 3:
                Player3 = controller;
                break;

        }
        arrows[index].SetActive(true);
        playerTokens[index].SetActive(true);
        //show client which token he is
    }

    public void DisconnectPlayer(int index)
    {
        connectedPlayers--;
        if (connectedPlayers == 0)
        {
            readyButton.SetActive(false);
        }
        switch (index)
        {
            case 0:
                Player0 = null;
                break;
            case 1:
                Player1 = null;
                break;
            case 2:
                Player2 = null;
                break;
            case 3:
                Player3 = null;
                break;

        }
        arrows[index].SetActive(false);
        playerTokens[index].SetActive(false);
    }

    public void StartGame()
    {
        inlobby = false;
        //change scene
    }

    enum InputSourceType {
        Lan,
        Controller,
        Arrows
    }

    public static void RegisterLanInput (NetworkInput connection) {
        if (!inlobby) {
            return;
        }
        switch (connection.inputState) {
            case InputType.Up:
                if (Player2 != null && Player2.Name == connection.Name) {
                    instance.DisconnectPlayer(2);
                } else if (Player0 == null) {
                    instance.ConnectPlayer( 0,new LanController(connection));
                }
                break;
            case InputType.Right:
                if (Player3 != null && Player3.Name == connection.Name) {
                    instance.DisconnectPlayer(3);

                } else if(Player1 == null) {
                    instance.ConnectPlayer(1, new LanController(connection));

                }
                break;
            case InputType.Down:
                if (Player0 != null && Player0.Name == connection.Name) {
                    instance.DisconnectPlayer(0);

                } else if(Player2 == null) {
                    instance.ConnectPlayer(2, new LanController(connection));
                }
                break;
            case InputType.Left:
                if (Player1 != null && Player1.Name == connection.Name) {
                    instance.DisconnectPlayer(1);
                } else if(Player3 == null) {
                    instance.ConnectPlayer(3, new LanController(connection));

                }
                break;
            case InputType.Cancel:
                if (Player0 != null && Player0.Name == connection.Name) {
                    instance.DisconnectPlayer(0);

                }
                if (Player1 != null && Player1.Name == connection.Name) {
                    instance.DisconnectPlayer(1);

                }
                if (Player2 != null && Player2.Name == connection.Name) {
                    instance.DisconnectPlayer(2);
                }
                if (Player3 != null && Player3.Name == connection.Name) {
                    instance.DisconnectPlayer(3);
                }
                break;
            default:
                break;
        }
    }

    public static PlayerController GetPlayerInput(int index) {
        switch (index) {
            case 0:
                return Player0;
            case 1:
                return Player1;
            case 2:
                return Player2;
            case 3:
                return Player3;
            default:
                break;
        }
        return null;
    }
}
public abstract class PlayerController {
    public string Name;

    public abstract float GetHorizontal();
    public abstract float GetVertical();
    public abstract bool GetConfirmation();
    public abstract bool GetCancel();
}

public class LanController : PlayerController {
    NetworkInput myConnection;

    public LanController(NetworkInput connection) {
        myConnection = connection;
        Name = myConnection.Name;
    }

    override
    public float GetHorizontal() {
        switch (myConnection.inputState) {
            case global::InputType.Right:
                return 1f;
            case global::InputType.Left:
                return -1f;
            default:
                return 0f;
        }
    }

    override
    public float GetVertical() {
        switch (myConnection.inputState) {
            case global::InputType.Up:
                return 1f;
            case global::InputType.Down:
                return -1f;
            default:
                return 0f;
        }
    }

    override
    public bool GetConfirmation() {
        Debug.Log("Confirmation");
        return (myConnection.inputState == global::InputType.Confirmation);
    }

    override
    public bool GetCancel() {
        Debug.Log("Cancel");
        return myConnection.inputState == global::InputType.Cancel;
    }
}
