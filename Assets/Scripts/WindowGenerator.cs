using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowGenerator : MonoBehaviour {

    public int timeToAppearWindow = 3;
    public GameObject normal_window;
    public GameObject tall_window;
    public GameObject generator_left;
    public GameObject generator_mid;
    public GameObject generator_right;
    public float windowSpeed = 125.0f; 

    private float counter = 0.0f;

    void Update() {
        counter += Time.deltaTime;

        if (counter >= timeToAppearWindow) {
            int random = Mathf.RoundToInt(Random.Range(1, 4));
            int randomWindowAppears = Mathf.RoundToInt(Random.Range(1, 3));
            GameObject windowAppears; 

            if(randomWindowAppears == 1)
            {
                windowAppears = normal_window;
            }
            else
            {
                windowAppears = tall_window;
            }

            print("NumRandom" + random);

            switch (random) {
                case 1:
                    GameObject.Instantiate(windowAppears, generator_left.transform.position, generator_left.transform.rotation);
                    break;
                case 2:
                    GameObject.Instantiate(windowAppears, generator_mid.transform.position, generator_mid.transform.rotation);
                    break;
                case 3:
                    GameObject.Instantiate(windowAppears, generator_right.transform.position, generator_right.transform.rotation);
                    break;
            }
            counter = 0.0f;
        }
    }

    public float GetWindowSpeed() {
        return windowSpeed; 
    }

    public void SetWindowSpeed(float newWindowSpeed) {
        windowSpeed = newWindowSpeed; 
    }
}
