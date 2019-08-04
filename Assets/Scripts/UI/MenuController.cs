using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Animator animator;

    public Animator textAnimator;

    public GameObject[] screens;

    public void ChangeScreen(int screen)
    {
        switch (screen)
        {
            case 0:
                textAnimator.enabled = true;
                animator.SetTrigger("MainToSplash");
                break;
            case 1:
                textAnimator.enabled = false;
                animator.SetTrigger("SplashToMain");
                break;
        }
    }
}
