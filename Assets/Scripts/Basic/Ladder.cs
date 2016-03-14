using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    private bool _onLadder = false;

    void Update()
    {

    }

    private void LadderBehaviour()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == GameTags.player)
            _onLadder = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == GameTags.player)
            _onLadder = false;
    }
}
