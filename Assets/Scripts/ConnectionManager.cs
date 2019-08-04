using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour {

    public static ConnectionManager instance = null;

    static List<NetworkInput> Connections;

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
    public static void CreateNewConnection (NetworkInput connection) {
        Connections.Add(connection);
    }

    public static void ExitConnection(NetworkInput connection) {
        Connections.Remove(connection);
    }

   

    private void Update() {
        foreach (NetworkInput connection in Connections) {
            InputManager.RegisterLanInput(connection);
        }
    }

}
