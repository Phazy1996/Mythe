using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //UI Buttons Main Menu
    [SerializeField]
    private GameObject howToPlayButton;
    [SerializeField]
    private GameObject settingsButton;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject quitButton;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameObject creditsButton;

    //UI Slider
    [SerializeField]
    private GameObject sfxSlider;
    [SerializeField]
    private GameObject musicSlider;

    //UI Text
    [SerializeField]
    private GameObject gameTitle;
    [SerializeField]
    private GameObject howToPlayText;
    [SerializeField]
    private GameObject howToPlayTitle;
    [SerializeField]
    private GameObject settingsMusic;
    [SerializeField]
    private GameObject settingsSFX;
    [SerializeField]
    private GameObject settingsTitle;
    [SerializeField]
    private GameObject creditsTitle;
    [SerializeField]
    private GameObject creditsText;


void Start()
    {
        backButton.SetActive(false);
        howToPlayTitle.SetActive(false);
        howToPlayText.SetActive(false);
        settingsTitle.SetActive(false);
        settingsSFX.SetActive(false);
        settingsMusic.SetActive(false);
        musicSlider.SetActive(false);
        sfxSlider.SetActive(false);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("FerryScene");
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
        settingsSFX.SetActive(true);
        settingsMusic.SetActive(true);
        musicSlider.SetActive(true);
        sfxSlider.SetActive(true);
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
        settingsSFX.SetActive(false);
        settingsMusic.SetActive(false);
        musicSlider.SetActive(false);
        sfxSlider.SetActive(false);
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
        settingsSFX.SetActive(false);
        settingsMusic.SetActive(false);
        musicSlider.SetActive(false);
        sfxSlider.SetActive(false);
        howToPlayTitle.SetActive(false);
        settingsTitle.SetActive(false);
        creditsText.SetActive(false);
        creditsTitle.SetActive(false);
    }

    
     public void QuitGame() {
        Application.Quit();
    }
    
}