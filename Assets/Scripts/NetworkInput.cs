using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class NetworkInput : NetworkBehaviour
{

    [SerializeField]
    GameObject LobbyRoom;
    public InputType inputState = InputType.None; //

    public string Name;

    [SyncVar]
    public int changeScene;

    [SerializeField]
    GameObject spaceShip;

    [SerializeField]
    float minDistance = 120f;
    Vector2 beginTouchPosition;

    bool canSwipe = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start() {
        if (!isLocalPlayer) {
            ConnectionManager.CreateNewConnection(this);
            Name = NetworkManager.singleton.playerName;
        }

    }

    public override void OnStartClient(){
        GameObject.Find("Join Room").SetActive(false);
    }

    public void JoinRoom(){
        GameObject.Find("Join Room").SetActive(true);
    }

    void Update() {
        if (!isLocalPlayer) {
            return;
        }

        if(changeScene == 1){
             SceneManager.LoadScene("ClientPlay");
             changeScene = 0;
        }

        if(Input.GetKey(KeyCode.W)){
            CmdUpdateState(InputType.Up);
        }
        if(Input.GetKey(KeyCode.S)){
            CmdUpdateState(InputType.Down);
        }
        if(Input.GetKey(KeyCode.A)){
            CmdUpdateState(InputType.Left);
        }
        if(Input.GetKey(KeyCode.D)){
            CmdUpdateState(InputType.Right);
        }
        if(Input.touchCount < 1)
            return;
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            canSwipe = true;
            beginTouchPosition = touch.position;
        }
        else if(touch.phase == TouchPhase.Moved && canSwipe){
            Vector2 endTouchPosition = touch.position;
            float dist = Vector2.Distance(beginTouchPosition,endTouchPosition);
            if(dist > minDistance){
                float dx = endTouchPosition.x-beginTouchPosition.x;
                float dy = endTouchPosition.y-beginTouchPosition.y;
                if(Mathf.Abs(dx) > Mathf.Abs(dy)){
                    if(dx > 0) {
                        CmdUpdateState(InputType.Right);
                        canSwipe = false;
                    }
                    else {
                        CmdUpdateState(InputType.Left);
                        canSwipe = false;
                    }
                }
                else{
                    if(dy > 0) {
                        CmdUpdateState(InputType.Up);
                        canSwipe = false;
                    }
                    else {
                        CmdUpdateState(InputType.Down);
                        canSwipe = false;
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
