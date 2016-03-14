using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {
    [SerializeField]
    private GameObject backToMenuButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
