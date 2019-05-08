using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advice : MonoBehaviour{

    public enum Side {
        left,
        right,
        top
    }

    Side side;

    //  Public variables
    public float timeToDisappear = 1.0f;
    public AudioClip audio; 

    //  Private variables
    private float counter;

    // Private methods
    private void Start() {
        GetComponent<AudioSource>().PlayOneShot(audio, 1.0f);

        switch (side) {
            case Side.right:
                GetComponent<SpriteRenderer>().flipX = true; 
                break;
            case Side.top:
                //TO DO: Cambiar el sprite a señal de top
                break;
        }
    }

    private void Update () {
        counter += Time.deltaTime; 

        if(counter >= timeToDisappear) {
            Destroy(this.gameObject);
        }
	}

    //  Public methods

    public void SetSide(Side newSide) {
        side = newSide; 
    }
}
