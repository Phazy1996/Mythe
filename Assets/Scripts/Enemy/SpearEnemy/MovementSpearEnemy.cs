using UnityEngine;
using System.Collections;

/*
 * This script is responsible for making the Hunter Enemy move around. it moves the enemy untill it bumps into an obstacle and then turns it around
 * when it gets a cue from the targeter script it will change its behaviour in the sense that it will try all it can to chase the player, instead of turning around it will jump over obstacles.
 * this script also gives a cue to the shooter script so that the enemy throws a spear at the appropriate time
 */


<<<<<<< HEAD
public class MovementSpearEnemy : MonoBehaviour {
=======
public class MovementSpearEnemy : MonoBehaviour
{
>>>>>>> jochembranch

    private Rigidbody2D _rb;
    private SpearShooter _SpearThrow;

    private Animator _Animator;

    private RaycastHit2D _LineOfFire;
    private RaycastHit2D _JumpCast;
    private RaycastHit2D _PlayerReticle;

    private IHealth _HunterHealth;
    private HunterHealth _HHealth;

    private GameObject _Player;

    private bool _FacingRight = true;
    private bool _CanJump = true;
    private bool _PlayerSighted;

    private int _PlayerMask;
    private int _ObstacleMask;
    private int _DoubleMask;
    private int _JumpCooldown = 25;
    private int _ShotCoolDown = 100;

    private Vector2 _JumpForce = new Vector2(0, 350);
    private Vector2 _MoveForce = new Vector2(2.2f, 0);
    private Vector2 _OriginScale;
    private Vector2 _NullVector = new Vector2(0, 0);

    private float _JumpProximity = 3f;

<<<<<<< HEAD
	void Start () 
=======
    void Start()
>>>>>>> jochembranch
    {
        _rb = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindWithTag(GameTags.player);
        //_SpearThrow = GameObject.FindWithTag("RShoot").GetComponent<SpearShooter>();

        _SpearThrow = transform.FindChild("Shooter").GetComponent<SpearShooter>();

        _PlayerMask = LayerMask.GetMask("Player");
        _ObstacleMask = LayerMask.GetMask("Ground");
        _DoubleMask = LayerMask.GetMask("Player", "Ground");

        _OriginScale = transform.localScale;

        _HunterHealth = GetComponent<IHealth>();

        _Animator = GetComponent<Animator>();

        _HHealth = GetComponent<HunterHealth>();
        //sign up for deplete health delegate
        _HHealth.DepleteHealth += Die;
<<<<<<< HEAD
	}
=======
    }
>>>>>>> jochembranch

    void OnEnable()
    {
        //sign up for deplete health delegate after respawning
        _HHealth.DepleteHealth += Die;
    }

    void Die()
    {
        Debug.Log("HOMER IS DEAD " + this.name);
        _HHealth.DepleteHealth -= Die;
        //put object back in object pool

        //ObjectPool.instance.PoolObject(gameObject);
    }
<<<<<<< HEAD
	
	void Update () 
    {
        if(_PlayerSighted == false)
=======

    void Update()
    {
        if (_PlayerSighted == false)
>>>>>>> jochembranch
            Patrol();
        //ProximityCheck();
        ResetJump();
        IgnoreCollision();
        ResetShotCooldown();
<<<<<<< HEAD
	}
=======
    }
>>>>>>> jochembranch

    void ResetShotCooldown()
    {
        Debug.Log("Decrease shot cooldown");
        _ShotCoolDown--;
<<<<<<< HEAD
        if(_ShotCoolDown < 0){
=======
        if (_ShotCoolDown < 0)
        {
>>>>>>> jochembranch
            _ShotCoolDown = 0;
        }
    }

    void OnMouseDown()
    {
        _HunterHealth.DecreaseHealth();
    }

    void IgnoreCollision()
    {
        Physics2D.IgnoreLayerCollision(9, 11, true);
    }

    void Jump()
    {
<<<<<<< HEAD
        if(_JumpCooldown == 0)
=======
        Debug.Log("I want to jump");
        if (_JumpCooldown == 0)
>>>>>>> jochembranch
        {
            _Animator.SetInteger("State", 2);
            _rb.AddForce(_JumpForce);
            _JumpCooldown = 25;
        }
    }

    void Patrol()
    {
<<<<<<< HEAD
        if (_FacingRight == true){ //walk right
            _Animator.SetInteger("State", 1);
            transform.Translate(_MoveForce * Time.deltaTime);
        }
        else if (_FacingRight == false){ // walk left
=======
        if (_FacingRight == true)
        { //walk right
            _Animator.SetInteger("State", 1);
            transform.Translate(_MoveForce * Time.deltaTime);
        }
        else if (_FacingRight == false)
        { // walk left
>>>>>>> jochembranch
            _Animator.SetFloat("State", 1);
            transform.Translate(-_MoveForce * Time.deltaTime);
        }
    }
<<<<<<< HEAD
    
    public void PlayerDetected(bool _PlayerIsDetected)
    {
        if(_PlayerIsDetected == true)
=======

    public void PlayerDetected(bool _PlayerIsDetected)
    {
        if (_PlayerIsDetected == true)
>>>>>>> jochembranch
        {
            //hunter should also check for obstacles in front and jump over
            _PlayerSighted = true;
        }
        else
        {
            //hunter should do nothing special
            _PlayerSighted = false;
        }
    }

    public void ProximityCheck()
    {
        //check in front of enemy for obstacles to jump over or check if an obstacle is too close
        //in wich case enemy should turn around

        //cast a raycast in front of enemy.
<<<<<<< HEAD
        if(_FacingRight)
=======
        if (_FacingRight)
>>>>>>> jochembranch
            _LineOfFire = Physics2D.Raycast(transform.position, Vector2.right, _JumpProximity, _ObstacleMask);
        else
            _LineOfFire = Physics2D.Raycast(transform.position, Vector2.left, _JumpProximity, _ObstacleMask);

        if (_PlayerSighted == true)
        {
<<<<<<< HEAD
            if(_LineOfFire.collider.tag == GameTags.ground || _LineOfFire.collider.tag == "NormalWall")
            {
                Jump();
            }
        }else
=======
            if (_LineOfFire.collider.tag == GameTags.ground || _LineOfFire.collider.tag == "NormalWall")
            {
                Jump();
            }
        }
        else
>>>>>>> jochembranch
        {
            //check proximity normaly
            //check if obstacle is too close on the right
            if (_FacingRight == true && _LineOfFire.distance < 0.76f && _LineOfFire.distance > 0)
            {
                TurnAround();
            }
            else if (_FacingRight == false && _LineOfFire.distance < 0.76f && _LineOfFire.distance > 0) //check if obstacle is too close on the left
            {
                TurnAround();
            }
        }
    }

    public void Attack()
    {
        //if the player is above enemy, jump up.
        //when player is in front of enemy, throw a spear
        //walk in direction of player

        PlayerPosCheck();
        PlayerDetected(true);
    }

    void PlayerTargeter()
    {
<<<<<<< HEAD
        Debug.Log(_ShotCoolDown);
=======
>>>>>>> jochembranch

        //if the hunter cant target the wolf player, lower the hight of the _PlayerReticle
        if (_FacingRight)
            _PlayerReticle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 2), Vector2.right, Mathf.Infinity, _DoubleMask);
        else
            _PlayerReticle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 2), Vector2.left, Mathf.Infinity, _DoubleMask);

<<<<<<< HEAD
        if(_PlayerReticle.collider.tag == GameTags.player)
=======
        if (_PlayerReticle.collider.tag == GameTags.player)
>>>>>>> jochembranch
        {
            //disable jumping when player can be shot 
            _JumpCooldown = 5;

            if (_FacingRight == true)
            {
                //start the throw spear animation
<<<<<<< HEAD
                if(_ShotCoolDown <= 0)
=======
                if (_ShotCoolDown <= 0)
>>>>>>> jochembranch
                {
                    Debug.Log("Throw spear");
                    _Animator.SetInteger("State", 4);
                    _ShotCoolDown = 200;
                }
<<<<<<< HEAD
                else if(_ShotCoolDown != 0)
=======
                else if (_ShotCoolDown > 0)
>>>>>>> jochembranch
                {
                    //_Animator.SetInteger("State", 0);
                }
            }
            else
            {
                //Start the throw spear animation
<<<<<<< HEAD
                if(_ShotCoolDown <= 0)
=======
                if (_ShotCoolDown <= 0)
>>>>>>> jochembranch
                {
                    Debug.Log("Throw spear");
                    _Animator.SetInteger("State", 4);
                    _ShotCoolDown = 200;
<<<<<<< HEAD
                }else if(_ShotCoolDown != 0)
=======
                }
                else if (_ShotCoolDown != 0)
>>>>>>> jochembranch
                {
                    //_Animator.SetInteger("State", 0);
                }
            }
        }
<<<<<<< HEAD
        else if(_PlayerReticle.collider.tag != GameTags.player)
=======
        else if (_PlayerReticle.collider.tag != GameTags.player)
>>>>>>> jochembranch
        {
            Patrol();
        }
    }

    void Throw()
    {
        //this function is called via an animation event
        _SpearThrow.ThrowSpear(_FacingRight);
    }

    void PlayerPosCheck()
    {
        //check what side of enemy player is on
        if (_Player.transform.position.x > transform.position.x)
        {
            //player is on the right
            if (_FacingRight == false)
            {
                //looking wrong way, fix it
                TurnAround();
<<<<<<< HEAD
            }else
=======
            }
            else
>>>>>>> jochembranch
            {
                //enemy looks in player direction, check if player is above enemy
                //if player is below enemy, enemy will simply walk towards player
                CheckAbove();
                PlayerTargeter();
            }
<<<<<<< HEAD
        }else{
=======
        }
        else
        {
>>>>>>> jochembranch
            //player is on the left
            if (_FacingRight == true)
            {
                //looking wrong way, fix it
                TurnAround();
<<<<<<< HEAD
            }else
=======
            }
            else
>>>>>>> jochembranch
            {
                //enemy looks in player direction, check if player is above enemy
                //if player is below enemy, enemy will simply walk towards player
                CheckAbove();
                PlayerTargeter();
            }
        }
    }

    void CheckAbove()
    {
        if (_Player.transform.position.y > transform.position.y)
        {
            //player is above enemy, enemy should jump
            Jump();
        }
<<<<<<< HEAD
        else{
=======
        else
        {
>>>>>>> jochembranch
            ProximityCheck();
        }
    }

    void TurnAround()
    {
        //turn the enemy around
        if (_FacingRight == true)
            _FacingRight = false;
        else if (_FacingRight == false)
            _FacingRight = true;
        FlipSprite();
    }

    void ResetJump()
    {
        _JumpCast = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, _ObstacleMask);
<<<<<<< HEAD
        if(_JumpCast.distance >= 0 && _JumpCast.distance < 0.05)
        {
            _Animator.SetInteger("State", 1);
            //_CanJump = true;
            _JumpCooldown--;
            if(_JumpCooldown < 0)
=======
        Debug.Log(_JumpCast.distance);
        if (_JumpCast.distance >= 0 && _JumpCast.distance < 0.06)
        {
            Debug.Log("Reset Jump");
            _Animator.SetInteger("State", 1);
            //_CanJump = true;
            _JumpCooldown--;
            if (_JumpCooldown < 0)
>>>>>>> jochembranch
            {
                _JumpCooldown = 0;
            }
        }
    }

    void FlipSprite()
    {
        //flip the sprite horizontally when walking left
        if (_FacingRight == true)
<<<<<<< HEAD
            transform.localScale = _OriginScale;  
=======
            transform.localScale = _OriginScale;
>>>>>>> jochembranch
        else if (_FacingRight == false)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
