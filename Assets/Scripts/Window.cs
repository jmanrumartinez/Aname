using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

    public GameObject player;
    public Sprite cleanWindowSprite; 
    public float windowSpeed = 5.0f; 

    private Rigidbody2D rb;
    private SpriteRenderer sr; 

    enum State {
        dirty, 
        clean
    }

    State state; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>() != null)
        {
            string playerState = player.GetComponent<PlayerController>().GetState();

            if (playerState == "going_up")
            {
                rb.velocity = Vector2.down * windowSpeed * Time.deltaTime;
            }
            else if (playerState == "stopped" || playerState == "going_down")
            {
                rb.velocity = Vector2.zero; 
            }
        }
    }

    public void SetWindowSpeed(float newSpeed)
    {
        windowSpeed = newSpeed;
    }

    public float GetWindowSpeed()
    {
        return windowSpeed; 
    }

    public string GetState()
    {
        string stateString = "";

        switch (state)
        {
            case State.clean:
                stateString = "clean";
                break;
            case State.dirty:
                stateString = "dirty";
                break; 
        }

        return stateString; 
    }

    public void ChangeToWindowCleared()
    {
        if(state != State.clean)
        {
            //TO DO: SI HAS PASADO MÁS DE 3 SEGUNDOS CON EL ESTADO DE CLEANING_WINDOW LA WINDOW PASA A ESTAR LIMPIA
            sr.sprite = cleanWindowSprite;
            state = State.clean;
        }
    }
    
}
