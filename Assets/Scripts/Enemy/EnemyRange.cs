using UnityEngine;
using System.Collections;

/*
 * this script determines the range of the enemy in wich it will notice the player and attack.
 * if the player is not withtin range it will give signal that the enemy must walk around.
 */

public class EnemyRange : MonoBehaviour {

    

    //scripts
    private EnemyMovement _Movement;
    //scripts

    //ints
    private int _LayerMask;
    //ints

    //floats
    [SerializeField] private float _EnemyRangeRadius;
    //floats


	void Start () 
    {
        
        //set layermask on wich to look for the player
        _LayerMask = LayerMask.GetMask("Player");

        _Movement = GetComponent<EnemyMovement>();
	}
	
	void Update () 
    {
        Scout();
	}

    void Scout()
    {
        //create overlap circle and return objects within range on the assigned layermask
        Collider2D _EnemyRange = Physics2D.OverlapCircle(transform.position, _EnemyRangeRadius, _LayerMask);

        //check if the object within range has the player tag
        if(_EnemyRange.gameObject.tag == GameTags.player)
        {
            Debug.Log("player in range");
            _Movement.Chase();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _EnemyRangeRadius);
    }
}
