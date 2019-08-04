using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance = null;

    public int initialLifeCount = 3;

    int[] PlayerLifeCounts = new int[4];

    public GameObject gameOverScreen;

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
        print("index " + index + " value " + PlayerLifeCounts[index]);
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
            EnemySpawner.instance.canSpawn = false;
            StartCoroutine(SlowMo());
            gameOverScreen.SetActive(true);
        }
    }

    public void SetInitialLives(bool[] players)
    {
        for(int i = 0; i < players.Length; i++)
        {
            if (players[i])
            {
                PlayerLifeCounts[i] = initialLifeCount;
            }
            else
            {
                PlayerLifeCounts[i] = 0;
            }
        }
    }

    IEnumerator SlowMo()
    {
        while (Time.timeScale > 0.2f)
        {
            Time.timeScale -= 0.1f;
            yield return null;
        }
    }
}
