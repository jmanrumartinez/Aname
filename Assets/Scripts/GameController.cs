using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {

    public Text scoreText;
    public PlayerController player; 
    public int scoreProfit = 50; //Score que vas a ganar por secondsScore
    public float secondsScore = 0.5f; //Segundos que vas a ganar scoreProfit

    private float secondsCounter = 0.0f; //secondsCounter para incrementar 

    private void Update()
    {
        UpdateScoreText(scoreText);
        //IncreasePoints(score, scoreProfit, secondsScore, secondsCounter); TEMPORAL

        //TEMPORAL hasta que se arregle IncreasePoints
        secondsCounter += Time.deltaTime;

        if (secondsCounter >= secondsScore)
        {
            player.AddScore(scoreProfit);
            secondsCounter = 0.0f;
        }
        //END TEMPORAL
    }

    private void UpdateScoreText(Text scoreTextField)
    {
        if (scoreTextField != null)
        {
            scoreTextField.text = "Score: " + player.GetScore();
        }
    }

    //Not working now
    private void IncreasePoints(int scorePlayer, int scoreToGain, float secondsToEarnScore, float secondsCounterToIncrease) {
        secondsCounterToIncrease += Time.deltaTime;
        print("secondsCounterToIncrease : " + secondsCounterToIncrease);

        if (secondsCounterToIncrease >= secondsToEarnScore)
        {
            scorePlayer += scoreToGain;
            secondsCounterToIncrease = 0.0f;
        }
    }

}
