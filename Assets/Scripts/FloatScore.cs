using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScore : MonoBehaviour {

    //  Public variables
    public float secondsToDisappear = 0.5f;

    //  Private variables
    private Vector3 offset = new Vector3(1.0f, 3.5f, 0.0f);
    private Vector3 randomizePos = new Vector3(0.5f, 0.0f, 0.0f);
    private GameObject player; 

    //  Private methods
	private void Start () {
        player = GameObject.Find("player");
        GetComponent<TextMesh>().text = player.GetComponent<PlayerController>().GetScoreWhileCleaning().ToString();

        transform.position += offset;
        transform.position += new Vector3(Random.Range(-randomizePos.x, randomizePos.x), Random.Range(-randomizePos.y, randomizePos.y), Random.Range(-randomizePos.z, randomizePos.z));

        Destroy(this.gameObject, secondsToDisappear);
    }

    private void Update()
    {
        if(player.GetComponent<PlayerController>().GetState() != "cleaning_window")
        {
            Destroy(this.gameObject);
        }
    }
}
