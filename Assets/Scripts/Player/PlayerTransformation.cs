using UnityEngine;
using System.Collections;

public class PlayerTransformation : MonoBehaviour {

    //SpriteRenderer
    private SpriteRenderer _playerRenderer;
    //SpriteRenderer

    //Bools
    public bool transitionMode = false;
     public bool wolfMode = false;
    //Bools


    void Start()
    {
        _playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

	void Update () 
    {
        TransformButton();
	}

    private void TransformButton()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!wolfMode)
            {
                StartCoroutine("WolfTransformation");        
            }
            else
                StartCoroutine("HumanTransformation");
            
        }
    }

    IEnumerator WolfTransformation()
    {
        int _secondsToWait = 1;

        transitionMode = true;

        _playerRenderer.color = Color.red;
        yield return new WaitForSeconds(_secondsToWait);
        _playerRenderer.color = Color.yellow;

        transitionMode = false;
        wolfMode = true;
    }

    IEnumerator HumanTransformation()
    {
        int _secondsToWait = 1;

        transitionMode = true;

        _playerRenderer.color = Color.red;
        yield return new WaitForSeconds(_secondsToWait);
        _playerRenderer.color = Color.black;

        transitionMode = false;
        wolfMode = false;

    }
}
