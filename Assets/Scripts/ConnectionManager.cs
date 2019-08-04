﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class ConnectionManager : NetworkBehaviour {


    [SerializeField]
    TextMeshProUGUI ipText;

    static List<NetworkInput> Connections;

    public static ConnectionManager instance = null;

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
        Connections = new List<NetworkInput>();

        SetIp();
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

    void SetIp(){
        string ip = GetLocalIPAddress();
        ipText.text = ip;
    }
    string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

}
