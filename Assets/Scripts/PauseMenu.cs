using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    [SerializeField]
    private bool isPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject pauseButtonCanvas;

	
	// Update is called once per frame
	void Update () {
       Pause();
	}

    void Pause() {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            pauseButtonCanvas.SetActive(false);
            Time.timeScale = 0f;
        }
        else {
            pauseMenuCanvas.SetActive(false);
            pauseButtonCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = 1f;
        }
    }

    void Resume() {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseButton()
    {
        isPaused = true;
    }

}
