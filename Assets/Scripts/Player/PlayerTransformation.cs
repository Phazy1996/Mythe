using UnityEngine;
using System.Collections;

public class PlayerTransformation : MonoBehaviour {

    //SpriteRenderer
    private SpriteRenderer _playerRenderer;
    //SpriteRenderer

    //Floats
    private float _horizontalAxis;
    //Floats
    
    //Bools
    public bool transitionMode = false;
     public bool wolfMode = false;
    //Bools


    void Start()
    {
        _playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        _groundedBoolean = this.gameObject.GetComponent<PlayerMovement>();

        _thisBoxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
<<<<<<< HEAD

       
=======
>>>>>>> b8b8d2c632a624103c81e712152827d93496828a
>>>>>>> 9aaef8192efa07192c4619c0b18ba8e2e3ee49f5
>>>>>>> ec90a866ac84aa2f84eb0700206cb0d147f4d5b7
    }

	void Update () 
    {
        TransformButton();
	}

    private void TransformButton()
    {
<<<<<<< HEAD
        _horizontalAxis = Input.GetAxis("Horizontal");

        if (_groundedBoolean._isGrounded && _horizontalAxis == 0)
=======
        if (Input.GetKeyDown(KeyCode.S))
>>>>>>> 9aaef8192efa07192c4619c0b18ba8e2e3ee49f5
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
