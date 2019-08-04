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
    // Start is called before the first frame update
    static PlayerController Player0;
    static PlayerController Player1;
    static PlayerController Player2;
    static PlayerController Player3;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    enum InputSourceType {
        Lan,
        Controller,
        Arrows
    }

    public static void RegisterLanInput (NetworkInput connection) {
        switch (connection.inputState) {
            case InputType.Up:
                if (Player2.Name == connection.Name) {
                    Player2 = null;
                } else if (Player0 == null) {
                    Player0 = new LanController(connection);
                }

                break;
            case InputType.Right:
                if (Player3.Name == connection.Name) {
                    Player3 = null;
                }
                else if(Player1 == null) {
                    Player1 = new LanController(connection);
                }
                break;
            case InputType.Down:
                if (Player0.Name == connection.Name) {
                    Player0 = null;
                }
                else if(Player2 == null) {
                    Player2 = new LanController(connection);
                }
                break;
            case InputType.Left:
                if (Player1.Name == connection.Name) {
                    Player1 = null;
                }
                else if(Player3 == null) {
                    Player3 = new LanController(connection);
                }
                break;
            case InputType.Cancel:
                if (Player0.Name == connection.Name) {
                    Player0 = null;
                }
                if (Player1.Name == connection.Name) {
                    Player1 = null;
                }
                if (Player2.Name == connection.Name) {
                    Player2 = null;
                }
                if (Player3.Name == connection.Name) {
                    Player3 = null;
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

    public abstract class PlayerController {
        public string Name;

        public abstract float GetHorizontal();
        public abstract float GetVertical();
        public abstract bool GetConfirmation();
        public abstract bool GetCancel();
    }

    public class LanController : PlayerController{
        NetworkInput myConnection;

        public LanController(NetworkInput connection) {
            myConnection = connection;
            Name = myConnection.Name;
        }

        override
        public float GetHorizontal() {
            switch (myConnection.inputState) {
                case InputType.Right:
                    return 1f;
                case InputType.Left:
                    return -1f;
                default:
                    return 0f;
            }
        }

        override
        public float GetVertical() {
            switch (myConnection.inputState) {
                case InputType.Up:
                    return 1f;
                case InputType.Down:
                    return -1f;
                default:
                    return 0f;
            }
        }

        override
        public bool GetConfirmation() {
            return (myConnection.inputState == InputType.Confirmation);
        }

        override
        public bool GetCancel() {
            return myConnection.inputState == InputType.Cancel;
        }
    }
}
