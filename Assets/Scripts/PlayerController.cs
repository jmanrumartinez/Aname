using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private enum Side {
        left,
        mid,
        right
    }

    private enum State {
        stopped,
        going_up,
        going_down,
        cleaning_window,
        game_over
    }

    //  Outlets
    public GameObject floatingScore;

    [Header("Teleporters")]
    public GameObject teleport_left;
    public GameObject teleport_mid;
    public GameObject teleport_right;

    //  Public variables 
    public float movementSpeed = 5.0f;
    public int scoreWhileCleaning = 25;

    public float timeToCleanWindow = 2.0f;

    //  Private variables
    private Rigidbody2D rb;
    private int score = 0;
    private Side side;
    private State state;

    private float counter = 0.0f;
    private float counterGiveScore = 0.0f;

    private float counterStopped = 0.0f;
    private int maxSecondsStopped = 10;
    
    //  Private methods
    private void Start() {
        side = Side.mid;
        state = State.stopped;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //if(state != State.game_over)
        //{
        //    CheckIfNotMoving(); //TEMPORAL
        //}

        CheckIfGameOver(); //TEMPORAL 

        print("State: " + state);

        //Controller LEFT - RIGHT
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (side == Side.mid) {
                ChangeSide(Side.left);
            } else if (side == Side.right) {
                ChangeSide(Side.mid);
            }

        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (side == Side.left) {
                ChangeSide(Side.mid);
            } else if (side == Side.mid) {
                ChangeSide(Side.right);
            }
        }

        //Controller UP - DOWN 
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.velocity = Vector2.up * movementSpeed * Time.deltaTime;
            state = State.going_up;
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            rb.velocity = Vector2.zero;
            state = State.stopped;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.velocity = Vector2.down * movementSpeed * Time.deltaTime;
            state = State.going_down;
        } else if (Input.GetKeyUp(KeyCode.DownArrow)) {
            rb.velocity = Vector2.zero;
            state = State.stopped;
        }

        //Controller SAFE-UP (CAUGHT)
        if (Input.GetKey(KeyCode.Space)) {
            state = State.going_up;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            state = State.stopped;
        }

        //Controller CLEAN-WINDOW

        if (Input.GetKey(KeyCode.E)) {
            state = State.cleaning_window;
        } else if (Input.GetKeyUp(KeyCode.E)) {
            state = State.stopped;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }

    private void ChangeSide(Side newSide) {

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

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Window") {
            print("Ha colisionado con window");
            if (collision.gameObject.GetComponent<Window>() != null) {
                if (state == State.cleaning_window) {
                    counter += Time.deltaTime;
                    counterGiveScore += Time.deltaTime;

                    if (counter >= timeToCleanWindow) {
                        collision.gameObject.GetComponent<Window>().ChangeToWindowCleared(this.gameObject);
                        counter = 0.0f;
                    }

                    if (counterGiveScore >= 0.5f) {
                        AddScore(scoreWhileCleaning);
                        ShowFloatingScore();
                        counterGiveScore = 0.0f;
                    }
                }
            }
        }
    }

    private void ShowFloatingScore() {
        Instantiate(floatingScore, transform.position, Quaternion.identity, transform);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Window") {
            counter = 0.0f; //Reseteamos el counter al salir de la ventana       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            state = State.game_over;
        }
    }

    private void CheckIfNotMoving() {
        if (state == State.stopped) {
            counterStopped += Time.deltaTime;

            if (counterStopped >= maxSecondsStopped) {
                state = State.game_over;
            }
        }
    }

    private void CheckIfGameOver() {
        if (state == State.game_over) {
            Time.timeScale = 0.0f;
        }
    }

    // Public methods
    public string GetState() {
        string stateString = "";

        if (state == State.going_down) {
            stateString = "going_down";
        } else if (state == State.going_up) {
            stateString = "going_up";
        } else if (state == State.stopped) {
            stateString = "stopped";
        } else if (state == State.cleaning_window) {
            stateString = "cleaning_window";
        }

        return stateString;
    }

    public int GetScore() {
        return score;
    }

    public void SetScore(int newScore) {
        score = newScore;
    }

    public void AddScore(int newScore) {
        score += newScore;
    }

    public int GetScoreWhileCleaning() {
        return scoreWhileCleaning;
    }
}
