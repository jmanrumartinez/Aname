﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public GameObject prevWindow;

    //  Outlets
    public WindowGenerator windowGenerator; 

    //  Private variables
    private float windowSpeed = 0.0f;
    private SpriteRenderer sr;
    private Vector2 savedOffset;

    //  Private methods
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        savedOffset = sr.material.mainTextureOffset;
    }

    private void Update() {
        windowSpeed = windowGenerator.GetWindowSpeed();
        transform.Translate(0, windowSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Finish") {
            transform.position = prevWindow.transform.position + new Vector3(0, 10f, 0);
        }
    }

}
