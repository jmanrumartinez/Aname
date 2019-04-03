using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {

    public Text scoreText;
    public PlayerController player;
    public GameObject enemy;
    public WindowGenerator windowGenerator; 
    public int scoreProfit = 50; //Score que vas a ganar por secondsScore
    public float secondsScore = 0.5f; //Segundos que vas a ganar scoreProfit
    private float secondsCounter = 0.0f; //secondsCounter para incrementar 

    private float counterToIncrementWindowSpeed = 0.0f;
    public int secondsToIncrementWindows = 10;
    public float percentageMultiplyIncrementWindowSpeed = 0.1f;



    private void Update()
    {
        UpdateScoreText(scoreText);
        //IncreasePoints(score, scoreProfit, secondsScore, secondsCounter); TEMPORAL
        //TEMPORAL hasta que se arregle IncreasePoints
        secondsCounter += Time.deltaTime;

        counterEnemyGenerator += Time.deltaTime;
        GenerateEnemies();

        ManageWindowSpeed();

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
    //End not working now

    private void ManageWindowSpeed() {
        counterToIncrementWindowSpeed += Time.deltaTime;
        float windowSpeed = windowGenerator.GetWindowSpeed();

        if (counterToIncrementWindowSpeed >= secondsToIncrementWindows) {
            windowGenerator.SetWindowSpeed(windowSpeed += 7.5f);
            counterToIncrementWindowSpeed = 0.0f;
            print("Se ha cambiado la velocidad de las nuevas ventanas a: " + windowGenerator.GetWindowSpeed());
        }
    }

    private float counterEnemyGenerator = 0.0f;

    private void GenerateEnemies() {
        //counterEnemyGenerator += Time.deltaTime;

        if(counterEnemyGenerator >= Random.Range(5, 10)) {
            Instantiate(enemy);
            counterEnemyGenerator = 0.0f; 
        }
    }
}
