using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkInput : NetworkBehaviour
{

    [SyncVar]
    int inputState = 0; //

    [SerializeField]
    GameObject spaceShip;

    [SerializeField]
    float minDistance = 120f;
    Vector2 beginTouchPosition;

    public override void OnStartServer()
    {
        base.OnStartServer();
        if(!isLocalPlayer){
            Instantiate(spaceShip, new Vector3(0,0,0), Quaternion.identity);
        }
    }

    void Update() {
        if(Input.touchCount < 1)
            return;
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            beginTouchPosition = touch.position;
        }
        else if(touch.phase == TouchPhase.Ended){
            Vector2 endTouchPosition = touch.position;
            float dist = Vector2.Distance(beginTouchPosition,endTouchPosition);
            if(dist > minDistance){
                float dx = endTouchPosition.x-beginTouchPosition.x;
                float dy = endTouchPosition.y-beginTouchPosition.y;
                if(Mathf.Abs(dx) > Mathf.Abs(dy)){
                    if(dx > 0) {
                        inputState = 2; // direita
                    }
                    else {
                        inputState = 4; // esquerda
                    }
                }
                else{
                    if(dy > 0) {
                        inputState = 1; // cima
                    }
                    else {
                        inputState = 3; // baixo
                    }
                }
            }

        }
    }



}
