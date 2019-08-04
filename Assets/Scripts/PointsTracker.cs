using TMPro;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{
    public static PointsTracker instance = null;

    public int[] points;
    public TextMeshProUGUI[] pointsTexts;

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

    private void Start()
    {
        for (int i = 0; i < 4; i++) {
            UpdatePoints(0, i);
        }
    }

    public void UpdatePoints(int change, int index)
    {
        points[index] += change;
        pointsTexts[index].text = points[index].ToString();
    }
}
