using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

    private bool _InWall = false;

    private int _LayerMask;

    private Vector2 _MoveVector = new Vector2(10, 0);
    private Vector2 _NullVector = new Vector2(0,0);
    private Vector2 _Scale;
    private Vector2 _RayOrigin;

    private bool _GoingRight = true;
    private bool _PlayerClose = false;

    private RaycastHit2D _SpearCollControl1;
    private RaycastHit2D _SpearCollControl2;
    private RaycastHit2D _SpearCollControl3;

    private Collider2D _SpearColl;

    void Start()
    {
        _SpearColl = GetComponent<Collider2D>();

        _LayerMask = LayerMask.GetMask("Player");

        if(gameObject.tag == "SpearLeft")
        {
            _MoveVector = new Vector2(-10,0);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            _GoingRight = false;
        }
    }

	void Update () 
    {
        transform.Translate(_MoveVector * Time.deltaTime);
        _RayOrigin = new Vector2((transform.position.x - 0.75f), transform.position.y);

        if(_GoingRight)
        {
            _RayOrigin = new Vector2((transform.position.x - 0.75f), transform.position.y);
        }
        else
        {
            _RayOrigin = new Vector2((transform.position.x + 0.75f), transform.position.y);
        }

        if(_InWall)
        {
            CheckProximity();
        }

        if(_PlayerClose == true)
        {
            _SpearColl.enabled = false;
            Debug.Log("Player is close");
        }
        else
        {
            _SpearColl.enabled = true;
            Debug.Log("Player not close anymore");
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == GameTags.player && _InWall == false)
        {
            Destroy(gameObject);
        } //check if spear is stuck in wall
        else if (coll.gameObject.tag == GameTags.ground)
        {
            _MoveVector = _NullVector;
            _InWall = true;
        }
    }

    void CheckProximity()
    {
        _SpearCollControl1 = Physics2D.Raycast(transform.position, -transform.up, 1, _LayerMask);
        _SpearCollControl2 = Physics2D.Raycast(-_RayOrigin, -transform.up, 1, _LayerMask);
        _SpearCollControl3 = Physics2D.Raycast(transform.position, -transform.right , 3, _LayerMask);

        Debug.DrawRay(transform.position, -transform.up);
        Debug.DrawRay(_RayOrigin, -transform.up);
        Debug.DrawRay(transform.position, -transform.right);

        if(_SpearCollControl1.collider.tag == GameTags.player || _SpearCollControl2.collider.tag == GameTags.player)
        {
            Debug.Log("collider close by");
            _PlayerClose = true;
        }else if (_SpearCollControl3.collider.tag == GameTags.player)
        {
            Debug.Log("player behind spear");
            _PlayerClose = true;
        }

        //check if player is not nearby
        if (_SpearCollControl1.collider.tag == null || _SpearCollControl2.collider.tag == null)
            _PlayerClose = false;
        else if (_SpearCollControl3.collider.tag == null)
            _PlayerClose = false;
    }
}