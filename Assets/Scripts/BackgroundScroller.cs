using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 8);
        transform.position = startPosition + Vector2.down * newPos;
    }
}