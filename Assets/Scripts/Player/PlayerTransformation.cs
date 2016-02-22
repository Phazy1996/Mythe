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
<<<<<<< HEAD
     public bool wolfMode = false;
    //Bools

=======
    public bool wolfMode = false;

    public bool wolfToHumanTransition = false;
    public bool humanToWolfTransition = false;

    private bool _runOnce = false;
    //Bools


    //Collider2D
    private BoxCollider2D _thisBoxCollider2D;
    //Collider2D

    //Scripts
    private PlayerMovement _groundedBoolean; // Checks if the player is grounded or not.
    //Scripts

>>>>>>> b8b8d2c632a624103c81e712152827d93496828a

    void Start()
    {
        _playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
<<<<<<< HEAD
=======
        _groundedBoolean = this.gameObject.GetComponent<PlayerMovement>();

        _thisBoxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
<<<<<<< HEAD

       
=======
>>>>>>> b8b8d2c632a624103c81e712152827d93496828a
>>>>>>> 9aaef8192efa07192c4619c0b18ba8e2e3ee49f5
    }

	void Update () 
    {
<<<<<<< HEAD
        TransformButton();
=======
            TransformButton();

           /// AdjustBoxCollider2D();
>>>>>>> b8b8d2c632a624103c81e712152827d93496828a
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
<<<<<<< HEAD
                StartCoroutine("WolfTransformation");        
=======

                _runOnce = false;

                if (!wolfMode)
                {
                    StartCoroutine("WolfTransformation");
                }
                else
                    StartCoroutine("HumanTransformation");
>>>>>>> b8b8d2c632a624103c81e712152827d93496828a
            }
            else
                StartCoroutine("HumanTransformation");
            
        }
    }

    IEnumerator WolfTransformation()
    {
        int _secondsToWait = 1;

        humanToWolfTransition = true;
        transitionMode = true;

        _playerRenderer.color = Color.red;
        yield return new WaitForSeconds(_secondsToWait);
        _playerRenderer.color = Color.yellow;

        transitionMode = false;
        humanToWolfTransition = false;
        wolfMode = true;

        if (!_runOnce)
        {
            AdjustBoxCollider2D();
            _runOnce = true;
        }

        
    }

    IEnumerator HumanTransformation()
    {
        int _secondsToWait = 1;

        wolfToHumanTransition = true;
        transitionMode = true;

<<<<<<< HEAD
        _playerRenderer.color = Color.red;
=======

>>>>>>> b8b8d2c632a624103c81e712152827d93496828a
        yield return new WaitForSeconds(_secondsToWait);
        _playerRenderer.color = Color.black;

        transitionMode = false;
        wolfToHumanTransition = false;
        wolfMode = false;

        if (!_runOnce)
        {
            AdjustBoxCollider2D();
            _runOnce = true;
        }

    }

    private void AdjustBoxCollider2D()
    {
        if (wolfMode)
        {
            _thisBoxCollider2D.size = new Vector2(2.5f, 1.5f);
            _thisBoxCollider2D.offset = new Vector2(0, -0.4f);
        }
        else
        {
            _thisBoxCollider2D.size = new Vector2(1f, 2.4f);
            _thisBoxCollider2D.offset = new Vector2(0, 0);
        }
            
            
    }
}
