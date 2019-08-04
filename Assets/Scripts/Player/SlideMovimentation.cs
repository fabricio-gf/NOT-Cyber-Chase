using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovimentation : MonoBehaviour{
    public Tile ActualTile;

    [SerializeField] float VerticalSpeed = 10f;
    [SerializeField] float HorizontalSpeed = 10f;

    public bool isMoving;

    public bool canMove = false;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActualTile == null) {
            ActualTile = FindObjectOfType<Tile>();
        }
        /* if (!isMoving && canMove) {
            //Input temporario
            if (Input.GetKeyDown(KeyCode.W)) {
                //moveUp
                moveUp();
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                //moveRight
                moveRight();
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                //moveDown
                moveDown();
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                //moveLeft
                moveLeft();
            }
        }*/

        Move();
    }

    void Move() {
        if (!isMoving) {
            return;
        }
        Vector2 Destination = ActualTile.transform.position;
        Vector2 myPosition = transform.position;
        Vector2 Direction = Destination - myPosition;

        if (Direction.magnitude <= 0.01f) {
            isMoving = false;
            return;
        }
        float speed;
        if (Mathf.Abs(Direction.x) > Mathf.Abs(Direction.y)) {
            speed = HorizontalSpeed;
        } else {
            speed = VerticalSpeed;
        }

        transform.position = Vector2.MoveTowards(myPosition, Destination, speed * Time.deltaTime);
    }

    public void moveUp() {
        if (isMoving || !canMove) return;

        if (ActualTile.upTile != null) {
            ActualTile = ActualTile.upTile;
            isMoving = true;
        }
    }

    public void moveRight() {
        if (isMoving || !canMove) return;

        if (ActualTile.rightTile != null) {
            ActualTile = ActualTile.rightTile;
            isMoving = true;
        }
    }

    public void moveDown() {
        if (isMoving || !canMove) return;

        if (ActualTile.downTile != null) {
            ActualTile = ActualTile.downTile;
            isMoving = true;
        }
    }

    public void moveLeft() {
        if (isMoving || !canMove) return;

        if (ActualTile.leftTile != null) {
            ActualTile = ActualTile.leftTile;
            isMoving = true;
        }
    }

}
