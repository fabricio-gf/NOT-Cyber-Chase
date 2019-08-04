using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class NetworkInput : NetworkBehaviour
{

    public InputType inputState = InputType.None; //

    [SyncVar]
    public string Name;

    [SerializeField]
    GameObject spaceShip;

    [SerializeField]
    float minDistance = 120f;
    Vector2 beginTouchPosition;

    public void Start() {
        if (!isLocalPlayer) {
            ConnectionManager.CreateNewConnection(this);
        }
    }

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
            CmdUpdateState(InputType.Up);
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
                        CmdUpdateState(InputType.Right);
                    }
                    else {
                        CmdUpdateState(InputType.Left);
                    }
                }
                else{
                    if(dy > 0) {
                        CmdUpdateState(InputType.Up);
                    }
                    else {
                        CmdUpdateState(InputType.Down);
                    }
                }
            }
        }
    }

        [Command]
    void CmdUpdateState(InputType newState)
    {
        inputState = newState;
    }

    private void LateUpdate() {
        if (!isLocalPlayer && inputState != InputType.None) {
            inputState = InputType.None;
        }
    }

}
