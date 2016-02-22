using UnityEngine;
using System.Collections;

public class BossBody : MonoBehaviour {

    private Rigidbody2D rb;

    private GameObject _Player;
    private GameObject _BossBody;
    private GameObject _LHand;
    private GameObject _RHand;
    private GameObject _LFoot;
    private GameObject _RFoot;
    private GameObject _Head;

    private float _LHandDist;
    private float _RHandDist;
    private float _LFootDist;
    private float _RFootDist;
    private float _HeadDist;

	void Start () 
    {
        _Player = GameObject.FindWithTag(GameTags.player);
        rb = GetComponent<Rigidbody2D>();

        _LHand = GameObject.FindWithTag("BossLeftHand");
        _RHand = GameObject.FindWithTag("BossRightHand");
        _LFoot = GameObject.FindWithTag("BossLeftFoot");
        _RFoot = GameObject.FindWithTag("BossRightFoot");
        _Head = GameObject.FindWithTag("BossHead");
	}
	
	void Update () 
    {
        CheckLeftHand();
        CheckRightHand();
        CheckLeftFoot();
        CheckRightFoot();
        CheckHead();
	}

    void CheckLeftHand()
    {
        //check distance to left hand
        _LHandDist = Vector2.Distance(transform.position, _LHand.transform.position);
        //check direction of left hand
        float _XDirection = _LHand.transform.position.x - transform.position.x;
        float _YDirection = _LHand.transform.position.y - transform.position.y;
        Debug.DrawRay(transform.position, new Vector2(_XDirection, _YDirection));
        //Debug.DrawLine(transform.position, _LHand.transform.position);
    }

    void CheckRightHand()
    {
        //check distance to Right hand
        _RHandDist = Vector2.Distance(transform.position, _RHand.transform.position);
        //check direction of right hand
        float _XDirection = _RHand.transform.position.x - transform.position.x;
        float _YDirection = _RHand.transform.position.y - transform.position.y;
        Debug.DrawRay(transform.position, new Vector2(_XDirection, _YDirection));
        //Debug.DrawLine(transform.position, _RHand.transform.position);
    }

    void CheckLeftFoot()
    {
        //check distance to left foot
        _LFootDist = Vector2.Distance(_LFoot.transform.position, transform.position);
        //check direction of left foot
        float _XDirection = _LFoot.transform.position.x - transform.position.x;
        float _YDirection = _LFoot.transform.position.y - transform.position.y;
        Debug.DrawRay(transform.position, new Vector2(_XDirection, _YDirection));
    }

    void CheckRightFoot()
    {
        //check distance to right foot
        _RFootDist = Vector2.Distance(_RFoot.transform.position, transform.position);
        //check direction of right foot
        float _XDirection = _RFoot.transform.position.x - transform.position.x;
        float _YDirection = _RFoot.transform.position.y - transform.position.y;
        Debug.DrawRay(transform.position, new Vector2(_XDirection, _YDirection));
    }

    void CheckHead()
    {
        //check distance to head
        _HeadDist = Vector2.Distance(_Head.transform.position, transform.position);
        //check direction of head
        float _XDirection = _Head.transform.position.x - transform.position.x;
        float _YDirection = _Head.transform.position.y - transform.position.y;
        Debug.DrawRay(transform.position, new Vector2(_XDirection, _YDirection));
    }
}
