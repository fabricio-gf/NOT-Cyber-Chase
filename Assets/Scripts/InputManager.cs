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
                if (Player0 == null) {
                    Player0 = new LanController(connection);
                }
                break;
            case InputType.Right:
                if (Player1 == null) {
                    Player1 = new LanController(connection);
                }
                break;
            case InputType.Down:
                if (Player2 == null) {
                    Player2 = new LanController(connection);
                }
                break;
            case InputType.Left:
                if (Player3 == null) {
                    Player3 = new LanController(connection);
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
        protected string name;

        public abstract float GetHorizontal();
        public abstract float GetVertical();
        public abstract bool GetConfirmation();
        public abstract bool GetCancel();
    }

    public class LanController : PlayerController{
        NetworkInput myConnection;

        public LanController(NetworkInput connection) {
            myConnection = connection;
            //name = myConnection.name;
        }
        
        override
        public float GetHorizontal() {
            return 0f;
        }

        override
        public float GetVertical() {
            return 0f;
        }

        override
        public bool GetConfirmation() {
            return false;
        }

        override
        public bool GetCancel() {
            return false;
        }
    }
}
