﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    enum Panel {
        mainmenu,
        play,
        credits,
        settings,
        twitter
    }

    //  Public variables
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject settingsCanvas;
    public GameObject backButton;
    public GameObject firstTime;

    public AudioClip uiClick;
    public AudioSource audioSource;

    //  Private variables
    private Panel panelPos = Panel.mainmenu;

    private void Start() {
        if (!PlayerPrefs.HasKey("firstTime")) {
            firstTime.SetActive(true);
        }
    }

    //  Private methods
    private void Update() {
        switch (panelPos) {
            case Panel.play:
                SceneManager.LoadScene(1);

                break;
            case Panel.settings:
                if (!settingsCanvas.activeSelf) {
                    settingsCanvas.SetActive(true);
                    mainMenuCanvas.SetActive(false);

                }
                break;
            case Panel.credits:
                if (!creditsCanvas.activeSelf) {
                    creditsCanvas.SetActive(true);
                    mainMenuCanvas.SetActive(false);

                }
                break;
            case Panel.twitter:
                Application.OpenURL("https://twitter.com/manru_");
                audioSource.PlayOneShot(uiClick, 1.0f);
                break;
            case Panel.mainmenu:
                if (!mainMenuCanvas.activeSelf) {
                    mainMenuCanvas.SetActive(true);
                    settingsCanvas.SetActive(false);
                    creditsCanvas.SetActive(false);

                }
                break;
        }

        if (panelPos != Panel.mainmenu) {
            backButton.SetActive(true);
        } else {
            backButton.SetActive(false);
        }
    }

    public void Play() {
        panelPos = Panel.play;
        audioSource.PlayOneShot(uiClick, 1.0f);
    }

    public void ShowCredits() {
        panelPos = Panel.credits;
        audioSource.PlayOneShot(uiClick, 1.0f);
    }

    public void ShowSettings() {
        panelPos = Panel.settings;
        audioSource.PlayOneShot(uiClick, 1.0f);
    }

    public void GoTwitter() {
        panelPos = Panel.twitter;
        audioSource.PlayOneShot(uiClick, 1.0f);
    }

    public void Back() {
        panelPos = Panel.mainmenu;
        audioSource.PlayOneShot(uiClick, 1.0f);
    }

    public void CloseFirstTime() {
        firstTime.SetActive(false);
    }
}
