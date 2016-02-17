using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //UI Buttons Main Menu
    public GameObject howToPlayButton;
    public GameObject settingsButton;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject backButton;
    public GameObject creditsButton;

    //UI Text
    public GameObject gameTitle;
    public GameObject howToPlayText;
    public GameObject howToPlayTitle;
    public GameObject settingsText;
    public GameObject settingsTitle;
    public GameObject creditsTitle;
    public GameObject creditsText;

void Start()
    {
        backButton.SetActive(false);
        howToPlayTitle.SetActive(false);
        howToPlayText.SetActive(false);
        settingsTitle.SetActive(false);
        settingsText.SetActive(false);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    public void PlayGame()
    {
        Application.LoadLevel("FerryScene");
    }

    public void HowToPlayButton()
    {
        backButton.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
        howToPlayButton.SetActive(false);
        creditsButton.SetActive(false);
        gameTitle.SetActive(false);
        howToPlayText.SetActive(true);
        howToPlayTitle.SetActive(true);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    public void SettingsButton()
    {
        backButton.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
        howToPlayButton.SetActive(false);
        creditsButton.SetActive(false);
        gameTitle.SetActive(false);
        howToPlayText.SetActive(false);
        settingsText.SetActive(true);
        settingsTitle.SetActive(true);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    public void CreditsButton()
    {
        backButton.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
        howToPlayButton.SetActive(false);
        creditsButton.SetActive(false);
        gameTitle.SetActive(false);
        howToPlayText.SetActive(false);
        settingsText.SetActive(false);
        settingsTitle.SetActive(false);
        creditsText.SetActive(true);
        creditsTitle.SetActive(true);
    }

    public void BackToMenuButton()
    {
        backButton.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
        quitButton.SetActive(true);
        howToPlayButton.SetActive(true);
        creditsButton.SetActive(true);
        gameTitle.SetActive(true);
        howToPlayText.SetActive(false);
        settingsText.SetActive(false);
        howToPlayTitle.SetActive(false);
        settingsTitle.SetActive(false);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    
     public void QuitGame() {
        Application.Quit();
    }
    
}