using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameObject[] playerInfos;

    public void ActivatePlayerInfos(bool[] activePlayers)
    {
        for(int i = 0; i < playerInfos.Length; i++)
        {
            if (activePlayers[i])
            {
                playerInfos[i].SetActive(true);
            }
        }
    }
}
