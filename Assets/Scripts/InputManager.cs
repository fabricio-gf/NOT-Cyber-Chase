using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        MonoBehaviour myConnection;
        LanController(MonoBehaviour connection) {
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
