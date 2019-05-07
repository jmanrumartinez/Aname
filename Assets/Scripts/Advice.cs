using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advice : MonoBehaviour {

    //  Private variables
    private bool isEnabled = false;
    private float aliveCounter = 0.0f; 

    //  Public variables
    public float timeToDisappear = 1.0f;

    //  Outlets
    public AudioClip audio;

    //  Private methods

    private void Update() {
        if (isEnabled) {
            aliveCounter += Time.deltaTime; 

            if(aliveCounter >= timeToDisappear) {
                gameObject.SetActive(false);
            }
        }
    }

    //  Public methods
    public void Enable() {
        GetComponent<AudioSource>().PlayOneShot(audio, 1.0f);
        isEnabled = true;
    }
}
