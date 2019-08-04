using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class NetworkInput : NetworkBehaviour
{

    [SyncVar]
    public string Name;

    [SerializeField]
    GameObject spaceShip;

    [SerializeField]
    float minDistance = 120f;
    Vector2 beginTouchPosition;

    public override void OnStartServer()
    {
        base.OnStartServer();
        if(!isLocalPlayer){
            //Talvez issu não seja função do networkInput (comment by cartaz)
            //Instantiate(spaceShip, new Vector3(0,0,0), Quaternion.identity);
            name = Name;
        }
    }

    void Update() {
        if (!isLocalPlayer) {
            return;
        }
        if(Input.GetKey(KeyCode.W)){
            inputState = (int)InputType.Up;
        }
        if(Input.touchCount < 1)
            return;
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            beginTouchPosition = touch.position;
        }
        else if(touch.phase == TouchPhase.Moved){
            Vector2 endTouchPosition = touch.position;
            float dist = Vector2.Distance(beginTouchPosition,endTouchPosition);
            if(dist > minDistance){
                float dx = endTouchPosition.x-beginTouchPosition.x;
                float dy = endTouchPosition.y-beginTouchPosition.y;
                if(Mathf.Abs(dx) > Mathf.Abs(dy)){
                    if(dx > 0) {
                        transform.position.x = (float)InputType.Right;
                    }
                    else {
                        transform.position.x = (float)InputType.Left;
                    }
                }
                else{
                    if(dy > 0) {
                        transform.position.x = (float)InputType.Up;
                    }
                    else {
                        transform.position.x = (float)InputType.Down;
                    }
                }
            }

        }
    }



}
