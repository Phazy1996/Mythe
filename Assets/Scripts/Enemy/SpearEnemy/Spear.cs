using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

    private int _LayerMask;

    private float _XDirection;
    private float _YDirection;

    private Vector2 _MoveVector = new Vector2(10, 0);
    private Vector2 _NullVector = new Vector2(0,0);
    private Vector2 _Scale;
    private Vector2 _RayOrigin;

    private bool _GoingRight = true;
    private bool _PlayerBelow = false;
    private bool _InWall = false;

    private RaycastHit2D _SpearCollControl;
    private Ray _ProxPlayerRay;

    private Collider2D _SpearColl;

    private Rigidbody2D _playerRb;

    private GameObject _Player;

    void Start()
    {
        _Player = GameObject.FindWithTag(GameTags.player);
        _playerRb = _Player.GetComponent<Rigidbody2D>();

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

        if(_PlayerBelow)
        {
            Debug.Log("Platform is not solid");
            _SpearColl.enabled = false;
        }
        else
        {
            Debug.Log("Platform is solid");
            _SpearColl.enabled = true;
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
        _XDirection = (_playerRb.position.x) - (transform.position.x);
        _YDirection = (_playerRb.position.y) - (transform.position.y);

        _ProxPlayerRay = new Ray(transform.position, new Vector2(_XDirection, _YDirection));
        _SpearCollControl = Physics2D.Raycast(_ProxPlayerRay.origin, _ProxPlayerRay.direction, 1, _LayerMask);

        Debug.DrawRay(_ProxPlayerRay.origin, _ProxPlayerRay.direction);

        if(_SpearCollControl.collider.tag == GameTags.player && (_playerRb.position.y) <= transform.position.y)
        {
            _PlayerBelow = true;
            Debug.Log("Player is underneath");
        }
        else if (_SpearCollControl.collider.tag == GameTags.player && (_playerRb.position.y) >= transform.position.y)
        {
            Debug.Log("Player is above");
            _PlayerBelow = false;
            _SpearColl.enabled = true;
        }
    }
}