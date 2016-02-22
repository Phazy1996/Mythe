using UnityEngine;
using System.Collections;

/*
 * this class makes the enemy move through the enviornment, it will jump over obstacles and attack the player when its within range 
 * it will be aware of its surroundings and react accordingly
 */

public class EnemyMovement : MonoBehaviour {

    

    //gameobjects & scripts
    private Rigidbody2D rb;
    private GameObject _Player;
    private Rigidbody2D _PlayerRb;
    //gameobjects, components & scripts

    //floats
    [SerializeField] private float _JumpProximity;
    //floats

    //vectors
    private Vector2 _EnemyMove = new Vector2(3f, 0);
    private Vector2 _EnemyJump = new Vector2(-1.5f, 350);
    //vectors

    //ints
    private int _LayerMask;
    //ints

    //booleans
    private bool _CanJump;
    private bool _FacingRight;
    //booleans



	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindWithTag(GameTags.player);
        _PlayerRb = _Player.GetComponent<Rigidbody2D>();
        _LayerMask = LayerMask.GetMask("Ground");
	}
	
	void Update () 
    {
        
        if(_FacingRight == true)
        {
            //Raycast to the right to detect when the enemy needs to jump over an obstacle
            //Jump proximity indicates at what distance the enemy needs to jump
            RaycastHit2D obstacleCheck = Physics2D.Raycast(transform.position, Vector2.right, _JumpProximity, _LayerMask);
            if (obstacleCheck.collider.tag == GameTags.ground && _CanJump == true)
            {
                //jump
                rb.AddForce(_EnemyJump);
                _CanJump = false;
            }
        }
        else
        {
            //Raycast to the right to detect when the enemy needs to jump over an obstacle
            RaycastHit2D obstacleCheck = Physics2D.Raycast(transform.position, Vector2.left, _JumpProximity, _LayerMask);
            if (obstacleCheck.collider.tag == GameTags.ground && _CanJump == true)
            {
                //jump
                rb.AddForce(_EnemyJump);
                _CanJump = false;
            }
        }
        
	}

    public void Chase()
    {
        //determine on what side of the enemy the player is positioned & move in that direction
        if (_PlayerRb.position.x > transform.position.x)
        {
            //rb.AddForce(_EnemyMove);
            transform.Translate(_EnemyMove * Time.deltaTime);
            _FacingRight = true;
        }
            
        else if (_PlayerRb.position.x < transform.position.x)
        {
            //rb.AddForce(-_EnemyMove);
            transform.Translate(-_EnemyMove * Time.deltaTime);
            _FacingRight = false;
        }
             
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        //reenable jumping when enemy hits the ground
        if(coll.gameObject.tag == GameTags.ground)
        {
            Debug.Log("reset jump");
            _CanJump = true;
        }
    }
    
}
