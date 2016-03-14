using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelEnder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == GameTags.player)
        {
            Endlevel();
        }
    }

    void Endlevel() {
        SceneManager.LoadScene(GameTags.WinScene);
    }
}
