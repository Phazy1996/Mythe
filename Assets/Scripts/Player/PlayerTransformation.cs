using UnityEngine;
using System.Collections;

public class PlayerTransformation : MonoBehaviour {

    //SpriteRenderer
    private SpriteRenderer _playerRenderer;
    //SpriteRenderer

    //Bools
    [SerializeField]
    private bool _isGrounded = false; // Is the player grounded, or not?
    public bool transitionMode = false;
    public bool wolfMode = false;
    //Bools

    //Scripts
    private PlayerMovement _groundedBoolean; // Checks if the player is grounded or not.
    //Scripts


    void Start()
    {
        _playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _groundedBoolean = this.gameObject.GetComponent<PlayerMovement>();
    }

	void Update () 
    {
       
            TransformButton();
	}

    private void TransformButton()
    {
        if (_groundedBoolean._isGrounded)
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
