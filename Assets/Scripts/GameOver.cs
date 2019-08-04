using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance = null;

    public int[] PlayerLifeCounts = new int[4];

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
    }

    public void LoseLife(int index)
    {
        PlayerLifeCounts[index]--;
    }

    public void CheckGameOver()
    {
        int count = 0;
        for(int i = 0; i < 4; i++)
        {
            if(PlayerLifeCounts[i] <= 0)
            {
                count++;
            }
        }
        if(count == 4)
        {
            //toggle game over
        }
    }
}
