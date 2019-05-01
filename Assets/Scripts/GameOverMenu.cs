using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOverMenu : MonoBehaviour {

    public Text yourScore;
    public Text yourHighScore; 
    public GameObject player; 

    private void Start() {
        yourScore.text = "Your score: " + player.GetComponent<PlayerController>().GetScore();
        yourHighScore.text = "High score: " + PlayerPrefs.GetInt("highScore");
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }

    public void Exit() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

}
