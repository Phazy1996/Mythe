using UnityEngine;
using System.Collections;

public class MovementSpearEnemy : MonoBehaviour {

    private Rigidbody2D _rb;
    private SpearShooter _SpearThrow;
    private RaycastHit2D _LineOfFire;

    private GameObject _Player;

    private bool _FacingRight = true;
    private bool _CanJump;

    private int _LayerMask;
    private int _ObstacleMask;
    private int _JumpCooldown;

    private Vector2 _JumpForce = new Vector2(0, 350);
    private Vector2 _MoveForce = new Vector2(3.5f, 0);

    private float _JumpProximity = 3f;

	void Start () 
    {
        _rb = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindWithTag(GameTags.player);
        _SpearThrow = GameObject.FindWithTag("RShoot").GetComponent<SpearShooter>();

        _LayerMask = LayerMask.GetMask("Player");
        _ObstacleMask = LayerMask.GetMask("Ground");
	}
	
	void Update () 
    {
        Patrol();
        FlipSprite();
	}

    void Jump()
    {
        if(_CanJump == true)
        {
            _rb.AddForce(_JumpForce);
            _CanJump = false;
        }
    }

    void Patrol()
    {
        if (_FacingRight == true) //walk right
            transform.Translate(_MoveForce * Time.deltaTime);
            
        else if (_FacingRight == false) // walk left
            transform.Translate(-_MoveForce * Time.deltaTime);
    }

    void ProximityCheck()
    {
        //check in front of enemy for obstacles to jump over or check if an obstacle is too close
        //in wich case enemy should turn around

        //cast a raycast in front of enemy.
        if(_FacingRight)
            _LineOfFire = Physics2D.Raycast(transform.position, Vector2.right, _JumpProximity, _ObstacleMask);
        else
            _LineOfFire = Physics2D.Raycast(transform.position, Vector2.left, _JumpProximity, _ObstacleMask);

        //check if obstacle is too close on the right
        if(_FacingRight == true && _LineOfFire.distance < 0.76f && _LineOfFire.distance > 0)
        {
            TurnAround();
            Debug.Log(_LineOfFire.distance);
        }else if(_FacingRight == false && _LineOfFire.distance < 0.76f && _LineOfFire.distance > 0) //check if obstacle is too close on the left
        {
            TurnAround();
            Debug.Log(_LineOfFire.distance);
        }
    }

    public void Attack()
    {
        //if the player is above enemy, jump up.
        //when player is in front of enemy, throw a spear
        //walk in direction of player

        PlayerPosCheck();
    }

    void PlayerPosCheck()
    {
        //check what side of enemy player is on
        if (_Player.transform.position.x > transform.position.x)
        {
            //player is on the right
            if (_FacingRight == false)
            {
                //looking wrong way
                TurnAround();
                if (_Player.transform.position.y > transform.position.y)
                {
                    //player is above enemy
                    Jump();
                }
                else
                {
                    //player is below enemy
                }
            }
            else
                Debug.Log("Player is on right side, looking correct way");
                //TurnAround();
        }
        else
        {
            //player is on the left
            if (_FacingRight == true)
            {
                //looking wrong way
                TurnAround();
                if (_Player.transform.position.y > transform.position.y)
                {
                    //player is above enemy
                    Jump();
                }
                else
                {
                    //player is below enemy
                }
            }
            else
                Debug.Log("Player is on left side, looking correct way");
                //TurnAround();    
        }
    }

    void TurnAround()
    {
        //turn the enemy around
        if (_FacingRight == true)
            _FacingRight = false;
        else if (_FacingRight == false)
            _FacingRight = true;
    }

    void FlipSprite()
    {
        //flip the sprite horizontally when walking left
        if (_FacingRight == true)
        {
            Debug.Log(_FacingRight + "dont flip sprite");
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        }    
        else if (_FacingRight == false)
        {
            Debug.Log(_FacingRight + "Flip sprite");
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }   
    }
}
