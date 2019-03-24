using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {

    public GameObject player;

    void Update () {
	    if(player.GetComponent<PlayerController>() != null)
        {
            // TO DO MOVING WINDOW IF PLAYER IS IN GOING_UP STATE 
        }	
	}
}
