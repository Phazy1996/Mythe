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

    private Rigidbody2D rb;
    private Rigidbody2D _playerRb;

    private GameObject _Player;
    private GameObject _Origin;
    private GameObject _StartPoint;
        void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    

    void OnEnable()
    {
        //determine what shooter the spear came from
        _StartPoint = GameObject.FindWithTag("RShoot");
        //set spear position to that of the shooter
        gameObject.transform.position = _StartPoint.transform.position;
    }

	void Update () 
    {
        transform.Translate(_MoveVector * Time.deltaTime);
        _RayOrigin = new Vector2((transform.position.x - 0.75f), transform.position.y);

        if(_GoingRight)
            _RayOrigin = new Vector2((transform.position.x - 0.75f), transform.position.y);
        else
            _RayOrigin = new Vector2((transform.position.x + 0.75f), transform.position.y);

        if(_InWall)
            CheckProximity();

        if(_PlayerBelow)
            _SpearColl.enabled = false;
        else
            _SpearColl.enabled = true;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //put object back in object pool upon colliding with player if its not stuck in wall
        if (coll.gameObject.tag == GameTags.player && _InWall == false)
        {
            ObjectPool.instance.PoolObject(gameObject);
        } //check if spear is stuck in wall
        else if (coll.gameObject.tag == GameTags.ground)
        {
            _MoveVector = _NullVector;
            _InWall = true;
            //turn on all constraints for rigidboy upon hitting wall, prevent from moving/rotating
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void CheckProximity()
    {
        _XDirection = (_playerRb.position.x) - (transform.position.x);
        _YDirection = (_playerRb.position.y) - (transform.position.y);

        _ProxPlayerRay = new Ray(transform.position, new Vector2(_XDirection, _YDirection));
        _SpearCollControl = Physics2D.Raycast(_ProxPlayerRay.origin, _ProxPlayerRay.direction, 1, _LayerMask);

        if(_SpearCollControl.collider.tag == GameTags.player && (_playerRb.position.y) <= transform.position.y)
        {
            _PlayerBelow = true;
        }
        else if (_SpearCollControl.collider.tag == GameTags.player && (_playerRb.position.y) >= transform.position.y)
        {
            _PlayerBelow = false;
            _SpearColl.enabled = true;
        }
    }
}