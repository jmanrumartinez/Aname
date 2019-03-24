using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporters : MonoBehaviour {

    public GameObject player; 

	void Update () {
        transform.position = new Vector2(0, player.transform.position.y);
	}
}
