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
    [SerializeField] private bool _wallJumpCapable = false; // Turns to true whenever the player touches a wall he could jump.
    [SerializeField] public bool _isGrounded = false; // Is the player grounded, or not?
    [SerializeField] private bool _isSprinting = false; // Is the player sprinting?

    private bool _runOnce = false; // Use this boolean to make something run once.
    private bool _runJumpsOnce = false; // Use this boolean to make something run once.
    private bool _spacePressed; // Is the space button pressed down?
    //Bools

    //RigidBody2D
    private Rigidbody2D _playerRigidBody2D;
    //RigidBody2D

    //Scripts
    private PlayerTransformation _checkMode;
    private PlayerFlip _checkFlip;
    //Scripts
    
    void Start()
    {
        _playerRigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        _checkMode = this.gameObject.GetComponent<PlayerTransformation>();
        _checkFlip = this.gameObject.GetComponent<PlayerFlip>();
    }

	void Update () 
	{
        Movement();
        SwitchValues();      
	}


    private void SwitchValues()
    {

        if (_checkMode.transitionMode) 
        {
            _amountJumps = 2;
            _movementSpeed = 0f;
            _jumpHeight = 0f;
            _jumpReach = 0f;
            _runJumpsOnce = false;
            _runOnce = false;
        }

            /*
             * Transition mode is the time between the player's transformation between human, and wolf form.
             * All values briefly become unusable (which is in this case, one second. See PlayerTransformation.cs for further references).
             */

        else if (_checkMode.wolfMode) // If you're a wolf, simply change values into...
        {
            if (!_runJumpsOnce)
            {
                _amountJumps = 1;
                _movementSpeed = 10f;
                _jumpHeight = 7f;
                _playerRigidBody2D.gravityScale = 2;
                _runJumpsOnce = true;
            }
           
            
            if (_checkFlip.facingRight)
                _jumpReach = 7f;
            else if (!_checkFlip.facingRight)
            _jumpReach = -7f;
            else if (Input.GetAxis("Horizontal") == 0)
            {
                _jumpReach = 0f;
            }

             

        }
        else // And if you're a human, then...
        {
            
            if (!_runOnce)
            {
                _movementSpeed = 5f;
                _jumpReach = 0f;
                _jumpHeight = 12f;
                _amountJumps = 0;
                _playerRigidBody2D.gravityScale = 3;
                _runOnce = true;
            }
           
        }
    }

    private void Movement()
	{
		float x = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2(x, 0f);


       transform.Translate(movement * _movementSpeed * Time.deltaTime);

       // _playerRigidBody2D.AddForce(movement * _movementSpeed);

       Sprint();
       Jump();
	}

    private void Sprint()
    {
        if (_checkMode.wolfMode)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _isSprinting = true;
                _movementSpeed = 15f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _isSprinting = false;
                _movementSpeed = 10f;
            }        
        }
    }

  
	private void Jump () 
	{
        if (!_spacePressed && Input.GetKey(KeyCode.Space) && _amountJumps < 2)
        {
            _playerRigidBody2D.velocity = new Vector2(_jumpReach, _jumpHeight);

            _spacePressed = true;
            _isGrounded = false;

            _amountJumps++;


             WallJumping();
		} 
        
        else if (!Input.GetKey(KeyCode.Space))
		{
            _spacePressed = false;
		}
		
	}


    private void WallJumping()
    {
        if (_wallJumpCapable && _checkFlip.facingRight)
            _jumpReach = -7f;
        else if (_wallJumpCapable && !_checkFlip.facingRight)
            _jumpReach = 7f;
        else
            _jumpReach = 0f;
    }



	void OnCollisionEnter2D (Collision2D hit)
	{
        if (hit.gameObject.tag == GameTags.ground)
        {
            _wallJumpCapable = false;
            _isGrounded = true;
            
   
            if (_checkMode.wolfMode)
                _amountJumps = 1; // Reset jumps.
            else
            {
                _jumpHeight = 12f;
                _amountJumps = 0;
                _jumpReach = 0f;
            }
                
        }

        else if (hit.gameObject.tag == GameTags.wall && !_checkMode.wolfMode)
        {
            _isGrounded = true;
            _wallJumpCapable = true;

            _amountJumps = 1; // Reset jumps.
            _jumpHeight = 15f;

           /* if (!_spacePressed)
                StartCoroutine("WallJumpClinge");
            */
        }
        
	}

    IEnumerator WallJumpClinge()
    {
        _playerRigidBody2D.gravityScale = 0;
        _jumpHeight = 0f;
        yield return new WaitForSeconds(1);
        _playerRigidBody2D.gravityScale = 3;
    }

}
