using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour {

    public static ConnectionManager instance = null;

    static List<MonoBehaviour> Connections;

    void Awake() {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //Destroy the fake
        else if (instance != this)
            Destroy(gameObject);

        //Dont destroy the ruler
        DontDestroyOnLoad(gameObject);
        //Long live the King!
    }

    /// <summary>
    /// Quando um NetworkBehaviour for spawnado, ele deve pedir pra ser cadastrado no network behaviour
    /// </summary>
    /// <param name="connection"></param>
    public static void CreateNewConnection (MonoBehaviour connection) {
        Connections.Add(connection);
    }

    public static void ExitConnection(MonoBehaviour connection) {
        Connections.Remove(connection);
    }

    public enum LanInputType {
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

    private void Update() {
        foreach (MonoBehaviour connection in Connections) {
            if (connection.input == ) {

            }
        }
    }

}
