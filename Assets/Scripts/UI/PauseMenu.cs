using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private bool isOnSettings = false;

    //Canvas
    public GameObject pauseMenuCanvas;

    //Text
    public GameObject settingsTitle;
    public GameObject settingsText;
    public GameObject pauseTitle;

    //Buttons
    public GameObject resumeButton;
    public GameObject settingsButton;
    public GameObject backToMainMenuButton;
    public GameObject backToResumeMenuButton;
    
        
    public void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }


     //Update is called once per frame
    void Update()
    {
        Pause();
    }

    //Setting the timescale to 0. Also makes the pause menu appear.
    //Also makes sure the settings screen remains in the update to keep the game paused.
    public void Pause()
    {
        if (isPaused == true && isOnSettings == false)
        {
            pauseMenuCanvas.SetActive(true);
            pauseTitle.SetActive(true);
            settingsTitle.SetActive(false);
            settingsText.SetActive(false);
            backToResumeMenuButton.SetActive(false);
            resumeButton.SetActive(true);
            settingsButton.SetActive(true);
            backToMainMenuButton.SetActive(true);

            Time.timeScale = 0f;
        }else if(isOnSettings == true)
        {
            Settings();
        }
        else {
            pauseMenuCanvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            isOnSettings = false;
            Time.timeScale = 1f;
        }

    }
    
    //What the settings screen has to display.
    void Settings()
    {
        isOnSettings = true;
        isPaused = false;
        if (isPaused == false && isOnSettings == true)
        {
            settingsTitle.SetActive(true);
            settingsText.SetActive(true);
            pauseTitle.SetActive(false);
            backToResumeMenuButton.SetActive(true);
            backToMainMenuButton.SetActive(false);
            resumeButton.SetActive(false);
            settingsButton.SetActive(false);

            Time.timeScale = 0f;
        }
    }

    //Send other screens back to the pause menu.
    void BackToResumeMenu()
    {
        isOnSettings = false;
        isPaused = true;
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Resume()
    {
        isPaused = false;
        isOnSettings = false;
        Time.timeScale = 1f;
    }


}
