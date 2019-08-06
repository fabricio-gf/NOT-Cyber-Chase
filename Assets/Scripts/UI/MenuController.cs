using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Animator animator;

    public Animator textAnimator;

    public GameObject[] screens;

    EmergencyInput ei;


    public GameObject[] playerTokens;
    public GameObject[] arrows;
    public GameObject readyButton;
    

    private void Awake()
    {
        Time.timeScale = 1;
        EmergencyInput.instance.ResetNotThisScene();

        ei = GameObject.FindGameObjectWithTag("Emergency").GetComponent<EmergencyInput>();
        ei.playerTokens = playerTokens;
        ei.arrows = arrows;
        ei.readyButton = readyButton;

    }

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
