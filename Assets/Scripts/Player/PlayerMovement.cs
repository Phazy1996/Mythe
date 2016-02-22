using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Floats
    [SerializeField] private float _movementSpeed = 5f; // Decides how fast the player can move.
    [SerializeField] private float _jumpHeight = 12f; // Decides how high the player could jump.
    [SerializeField] private float _jumpReach = 0f; // Decides how far the player could jump.
    //Floats

    //Int
	[SerializeField] private int _amountJumps = 0; // Keeps track of how many times the player has jumped.
    //Int

    //Bools
    [SerializeField] private bool _isGrounded = false; // Is the player grounded, or not?
	private bool _spacePressed; // Is the space button pressed down?

    private bool _runOnce = false;
    //Bools

    //RigidBody2D
    private Rigidbody2D _thisRigidBody2D;
    //RigidBody2D

    //Scripts
    private PlayerTransformation _checkMode;
    private PlayerFlip _checkFlip;
    //Scripts
    
    void Start()
    {
        _thisRigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        _checkMode = this.gameObject.GetComponent<PlayerTransformation>();
        _checkFlip = this.gameObject.GetComponent<PlayerFlip>();
    }

	void Update () 
	{
        SwitchValues();
        Movement();
		Jump ();
	}

    void SwitchValues()
    {

        if (_checkMode.transitionMode) 
        {
            _amountJumps = 2;
            _movementSpeed = 0f;
            _jumpHeight = 0f;
            _jumpReach = 0f;
        }

            /*
             * Transition mode is the time between the player's transformation between human, and wolf form.
             * All values briefly become unusable (which is in this case, one second. See PlayerTransformation.cs for further references).
             */

        else if (_checkMode.wolfMode) // If you're a wolf, simply change values into...
        {
            if (!_runOnce)
            {
                _amountJumps = 1;
                _runOnce = true;
            }
            _runOnce = false;
           
<<<<<<< HEAD
            
            if (_checkFlip._facingRight)
                _jumpReach = 7f;
=======

            _movementSpeed = 10f;
            _jumpHeight = 5f;

            /*
            if (_checkFlip.facingRight)
                _jumpReach = -10f;
>>>>>>> 0db8e5b2a5a4520074f78afbb4eb7c046ac32151
            else
            _jumpReach = 10f;

            _thisRigidBody2D.gravityScale = 1;
             */

        }
        else // And if you're a human, then...
        {
            _movementSpeed = 5f;
            _jumpReach = 0f;
        }
    }

    void Movement()
	{
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
        transform.Translate(movement * _movementSpeed * Time.deltaTime);     
	}

  
	void Jump () 
	{
        if (!_spacePressed && Input.GetKey(KeyCode.Space) && _amountJumps < 2)
        {
            _spacePressed = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(_jumpReach, _jumpHeight);
            _isGrounded = false;
            _amountJumps++;

		} 
        
        else if (!Input.GetKey(KeyCode.Space))
		{
            _spacePressed = false;
		}
		
	}

<<<<<<< HEAD

    private void WallJumping()
    {
        if (_wallJumpCapable && _checkFlip._facingRight)
            _jumpReach = -7f;
        else if (_wallJumpCapable && !_checkFlip._facingRight)
            _jumpReach = 7f;
        else
            _jumpReach = 0f;
    }



=======
>>>>>>> 0db8e5b2a5a4520074f78afbb4eb7c046ac32151
	void OnCollisionEnter2D (Collision2D hit)
	{
        if (hit.gameObject.tag == GameTags.ground)
        {
            _isGrounded = true;
   
            if (!_checkMode.wolfMode)
            {
                _jumpHeight = 12f;
                _amountJumps = 0; // Reset jumps.
            }
        }

        else if (hit.gameObject.tag == GameTags.wall && !_checkMode.wolfMode)
        {
            _isGrounded = true;
            _amountJumps = 1; // Reset jumps.
            _jumpHeight = 15f;
        }
        
	}

    

}
