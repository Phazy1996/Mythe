using UnityEngine;
using System.Collections;

public class SpearEnemyTargeter : MonoBehaviour {

    private GameObject _Player;
    private Rigidbody2D _PlayerRb;
    private SpearEnemyMovement _SEnemyMovement;

    private MovementSpearEnemy _MSpearEnemy;

    //the layermask the enemy has to check for. this mask contains the mask of the player and the masks of the objects the player can hide behind
    [SerializeField] private LayerMask _TargetMask;

	void Start () 
    {
        _Player = GameObject.FindWithTag(GameTags.player);
        _PlayerRb = _Player.GetComponent<Rigidbody2D>();
        _SEnemyMovement = GetComponent<SpearEnemyMovement>();

        _MSpearEnemy = GetComponent<MovementSpearEnemy>();
	}
	
	void Update () 
    {
        //Set direction in wich the raycast must be cast
        float _XDirection = (_PlayerRb.position.x) - (transform.position.x);
        float _YDirection = (_PlayerRb.position.y) - (transform.position.y);

        //_Renderer.color = Color.yellow;

        //determine enemy's line of sight. constantly look at player
        Ray lineOfSight = new Ray(new Vector3(transform.position.x,transform.position.y + 1f,transform.position.z), new Vector2(_XDirection, _YDirection));
        //check what is within line of sight, if player is in line of sight take action
        RaycastHit2D withinSight = Physics2D.Raycast(lineOfSight.origin, lineOfSight.direction, Mathf.Infinity, _TargetMask);
        if(withinSight.collider.tag == GameTags.player)
        {
            //player is within sight, jump if needed to take aim
            _MSpearEnemy.Attack();
        }
        else
        {   
            _MSpearEnemy.PlayerDetected(false);
            _MSpearEnemy.ProximityCheck();
        }
	}
}