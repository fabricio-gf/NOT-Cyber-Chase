using TMPro;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{
    public int[] points;
    public TextMeshProUGUI[] pointsTexts;



    public void UpdatePoints(int change, int index)
    {
        points[index] += change;
        pointsTexts[index].text = points[index].ToString();
    }
}
