using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D rb;
    public SpriteRenderer sr; 
    public float movementSpeed = 5.0f;

    //Left generators
    public GameObject generator_left_top;
    public GameObject generator_left_mid;
    public GameObject generator_left_bottom;

    //Right generators
    public GameObject generator_right_top;
    public GameObject generator_right_mid;
    public GameObject generator_right_bottom;

    //Top generators
    public GameObject generator_top_left;
    public GameObject generator_top_mid;
    public GameObject generator_top_right;

    //Top-sprites
    [Header("Top Sprites")]
    public Sprite[] topSprites;

    //  Advisors
    private GameObject[] advisors; 

    enum InitialSide {
        left,
        right,
        top
    }

    InitialSide initialSide;

    private void Start() {
        GetComponent<SpriteRenderer>().enabled = false; //TEMPORAL, para arreglar el bug del fantasma para la entrega del pre-layer

        generator_left_top = GameObject.Find("generator_left_top");
        generator_left_mid = GameObject.Find("generator_left_mid");
        generator_left_bottom = GameObject.Find("generator_left_bottom");


        generator_right_top = GameObject.Find("generator_right_top");
        generator_right_mid = GameObject.Find("generator_right_mid ");
        generator_right_bottom = GameObject.Find("generator_right_bottom");


        generator_top_left = GameObject.Find("generator_top_left");
        generator_top_mid = GameObject.Find("generator_top_mid");
        generator_top_right = GameObject.Find("generator_top_right");

        int randomSide = Random.Range(1, 4);
        int randomPos = Random.Range(1, 4);

        switch (randomSide) {
            case 1:
                initialSide = InitialSide.left;
                print("initialSide: " + initialSide);

                switch (randomPos) {
                    case 1:
                        rb.position = generator_left_top.transform.position;
                        break;
                    case 2:
                        rb.position = generator_left_mid.transform.position;
                        break;
                    case 3:
                        rb.position = generator_left_bottom.transform.position;
                        break;
                }
                break;
            case 2:
                initialSide = InitialSide.top;
                print("initialSide: " + initialSide);

                int randSprite = Random.Range(0, topSprites.Length);
                GetComponent<SpriteRenderer>().sprite = topSprites[randSprite];

                movementSpeed += movementSpeed * Random.Range(0.2f, 0.6f); 

                switch (randomPos) {
                    case 1:
                        rb.position = generator_top_left.transform.position;
                        break;
                    case 2:
                        rb.position = generator_top_right.transform.position;
                        break;
                    case 3:
                        rb.position = generator_top_mid.transform.position;
                        break;
                }
                break;
            case 3:
                initialSide = InitialSide.right;
                sr.flipX = true;
                print("initialSide: " + initialSide);
                switch (randomPos) {
                    case 1:
                        rb.position = generator_right_top.transform.position;
                        break;
                    case 2:
                        rb.position = generator_right_mid.transform.position;
                        break;
                    case 3:
                        rb.position = generator_right_bottom.transform.position;
                        break;
                }
                
                break;
        }
    }

    float counterToAppear = 0.0f; 

    private void Update() {
        Move();

        counterToAppear += Time.deltaTime; 

        if(counterToAppear >= 0.3f) {
            GetComponent<SpriteRenderer>().enabled = true; 
        }
    }

    private void Move() {
        switch (initialSide){
            case InitialSide.left:
                rb.velocity = Vector2.right * movementSpeed * Time.deltaTime;
                break;
            case InitialSide.top:
                rb.velocity = Vector2.down * movementSpeed * Time.deltaTime;
                break;
            case InitialSide.right:
                rb.velocity = Vector2.left * movementSpeed * Time.deltaTime;
                break;
        }
    }

    public void SetMovementSpeed(float newMovementSpeed) {
        movementSpeed = newMovementSpeed; 
    }
}
