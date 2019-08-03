using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float totalDelay;

    public MatchManager matchManager;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartCountdown()
    {
        animator.SetTrigger("StartCountdown");
        StartCoroutine(CountdownDelay());
    }

    IEnumerator CountdownDelay()
    {
        yield return new WaitForSeconds(totalDelay);
        matchManager.OnGameStart?.Invoke();
    }
}
