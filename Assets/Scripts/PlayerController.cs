using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject teleport_left;
    public GameObject teleport_mid;
    public GameObject teleport_right;
    public float movementSpeed = 5.0f; 

    private Rigidbody2D rb;

    enum Side {
        left, 
        mid, 
        right
    }

    enum State {
        stopped, 
        going_up, 
        going_down
    }

    Side side;
    State state; 

    private void Start()
    {
        side = Side.mid;
        state = State.stopped; 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        print("State: " + state);

        //Controller LEFT - RIGHT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(side == Side.mid)
            {
                ChangeSide(Side.left);
            }else if(side == Side.right)
            {
                ChangeSide(Side.mid);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(side == Side.left)
            {
                ChangeSide(Side.mid);
            }
            else if(side == Side.mid)
            {
                ChangeSide(Side.right);
            }
        }

        //Controller UP - DOWN 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * movementSpeed * Time.deltaTime;
            state = State.going_up; 
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            rb.velocity = Vector2.zero;
            state = State.stopped;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * movementSpeed * Time.deltaTime;
            state = State.going_down;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) {
            rb.velocity = Vector2.zero;
            state = State.stopped;
        }
    }

    void ChangeSide(Side newSide)
    {

        switch (newSide) {
            case Side.left:
                transform.position = teleport_left.transform.position; 
                break;
            case Side.mid:
                transform.position = teleport_mid.transform.position;
                break;
            case Side.right:
                transform.position = teleport_right.transform.position;
                break;
        }

        side = newSide;
        print("Se ha cambiado a: " + side);
    }

}
