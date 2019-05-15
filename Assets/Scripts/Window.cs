using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {

    public GameObject player;
    public Sprite cleanWindowSprite;
    public int scoreWhenCleaned = 250;
    public GameObject generator; 
    private WindowGenerator windowGenerator;
    public AudioSource audioSource;
    public AudioClip clipWhenCleaned;

    [Header("Player")]
    public int scoreToDecrease = 100; 

    private SpriteRenderer sr;
    private float windowSpeed;

    //  Outlets

    public GameObject feedbackPrefab; 

    enum State {
        dirty,
        clean
    }

    State state;

    private void Start() {
        player = GameObject.Find("player");
        sr = GetComponent<SpriteRenderer>();

        generator = GameObject.Find("generators");
        windowGenerator = generator.GetComponent<WindowGenerator>();
    }

    void Update() {
        //rb.velocity = Vector2.down * windowSpeed * Time.deltaTime;
        transform.Translate(0,windowSpeed*Time.deltaTime,0);
        windowSpeed = windowGenerator.GetWindowSpeed();
    }

    public void SetWindowSpeed(float newSpeed) {
        windowSpeed = newSpeed;
    }

    public float GetWindowSpeed() {s
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
            audioSource.PlayOneShot(clipWhenCleaned, 1.0F);

            //  Cuando el estado cambia a limpio, instanciamos el prefab feeback y le asignamos una posición con un offset. 
            float offset = GetComponent<BoxCollider2D>().size.y / 2; 
            GameObject feedback = Instantiate(feedbackPrefab, transform);
            feedback.GetComponent<Transform>().localPosition = new Vector3(0.0f, offset + 1.0f,-1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "WindowBorder") {
            if (state.Equals(State.dirty)) {
                player.GetComponent<PlayerController>().DecreaseScore(scoreToDecrease); 
                //  TODO: Show increased score feedback canvas
            }
            Destroy(this.gameObject);
        }
    }

}
