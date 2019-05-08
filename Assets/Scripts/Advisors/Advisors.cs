using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisors : MonoBehaviour {

    public enum Side {
        left,
        right, 
        top
    }

    Side side;

    //  Private variables

    //  Public variables
    public GameObject[] advisors;
    public GameObject advicePrefab; 

    //  Public methods
    public void ShowAdvice(Side newSide) {
        GameObject instancedElement; 

        switch (newSide) {
            case Side.left:
                instancedElement = Instantiate(advicePrefab, advisors[0].transform.position, advisors[0].transform.rotation);
                //TO DO
                break;
            case Side.right:
                instancedElement = Instantiate(advicePrefab, advisors[1].transform.position, advisors[0].transform.rotation);
                instancedElement.GetComponent<Advice>().SetSide(Advice.Side.right);
                //TO DO
                break;
            case Side.top:
                instancedElement = Instantiate(advicePrefab, advisors[2].transform.position, advisors[0].transform.rotation);
                //TO DO
                break;
        }
    }

}
