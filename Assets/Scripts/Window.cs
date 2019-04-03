using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {

    public GameObject player;
    public Sprite cleanWindowSprite;
    public int scoreWhenCleaned = 250;
    public GameObject generator; 
    private WindowGenerator windowGenerator; 

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float windowSpeed;

    enum State {
        dirty,
        clean
    }

    State state;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        sr = GetComponent<SpriteRenderer>();

        generator = GameObject.Find("generators");
        windowGenerator = generator.GetComponent<WindowGenerator>();

        windowSpeed = windowGenerator.GetWindowSpeed();
    }

    void Update() {
        rb.velocity = Vector2.down * windowSpeed * Time.deltaTime;
    }

    public void SetWindowSpeed(float newSpeed) {
        windowSpeed = newSpeed;
    }

    public float GetWindowSpeed() {
        return windowSpeed;
    }

    public string GetState() {
        string stateString = "";

        switch (state) {
            case State.clean:
                stateString = "clean";
                break;
            case State.dirty:
                stateString = "dirty";
                break;
        }

        return stateString;
    }

    public void ChangeToWindowCleared(GameObject player) {
        if (state != State.clean && player.tag == "Player") {
            sr.sprite = cleanWindowSprite;
            state = State.clean;
            player.GetComponent<PlayerController>().AddScore(scoreWhenCleaned);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "WindowBorder") {
            Destroy(this.gameObject);
        }
    }

}
