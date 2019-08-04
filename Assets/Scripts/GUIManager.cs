using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance = null;

    public GameObject[] playerInfos;

    public TextMeshProUGUI[] bombs;

    public GameObject[] player1Life;
    public GameObject[] player2Life;
    public GameObject[] player3Life;
    public GameObject[] player4Life;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

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

    public void ChangeBombs(int index, int number)
    {
        bombs[index].text = "x" + number;
        //if number == 0
    }

    public void ChangeLife(int index, int number)
    {
        switch (index)
        {
            case 0:
                for(int i = 0; i < 3; i++)
                {
                    if(i < number)
                    {
                        player1Life[i].SetActive(true);
                    }
                    else
                    {
                        player1Life[i].SetActive(false);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    if (i < number)
                    {
                        player2Life[i].SetActive(true);
                    }
                    else
                    {
                        player2Life[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    if (i < number)
                    {
                        player3Life[i].SetActive(true);
                    }
                    else
                    {
                        player3Life[i].SetActive(false);
                    }
                }
                break;
            case 4:
                for (int i = 0; i < 3; i++)
                {
                    if (i < number)
                    {
                        player4Life[i].SetActive(true);
                    }
                    else
                    {
                        player4Life[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
