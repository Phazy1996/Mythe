using UnityEngine;
using System.Collections;

/*
 * This script controlls the shockwave send out by the boss after it has been send out.
 * it handles speed, collision and deactivation
 */

public class ShockWave : MonoBehaviour {

    private int _Rektimer;
    private bool _IsLeftShockwave;
    private Vector2 _WaveMoveVector = new Vector2(5,0);
    private GameObject _Boss;
    private GameObject _ShockStartPoint;

	void Start () 
    {
        _Boss = GameObject.FindWithTag("Boss");
        CheckSide();
        
        //flip sprite for shockwave going right
        if(_IsLeftShockwave == false)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
	}
	
    void OnEnable()
    {
        //find appropriate starting position for shockwave
        if (gameObject.tag == "ShockL")
            _ShockStartPoint = GameObject.FindWithTag("BossLShooter");
        else if (gameObject.tag == "ShockR")
            _ShockStartPoint = GameObject.FindWithTag("BossRShooter");
        //set shockwave position to start position
        gameObject.transform.position = _ShockStartPoint.transform.position;
    }

	void Update () 
    {
	    MoveWave();
	}

    void CheckSide()
    {
        //check what side shockwave is on.
        if (gameObject.tag == "ShockL")
            _IsLeftShockwave = true;
        else
            _IsLeftShockwave = false;
    }
    
    void RemoveAfterTime()
    {
        //put shockwaves back in object pool after certain time
        if(_Rektimer > 250)
        {
            //Remove shockwave
            ObjectPool.instance.PoolObject(gameObject);
        }
        else
        {
            _Rektimer++;
        }
    }

    void MoveWave()
    {
        if (_IsLeftShockwave)
            //move shockwave left
            transform.Translate(-_WaveMoveVector * Time.deltaTime);
        else
            //move shockwave right
            transform.Translate(_WaveMoveVector * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == GameTags.ground)
        {
            ObjectPool.instance.PoolObject(gameObject);
            Debug.Log("Shockwave hit wall");
        }else if(coll.gameObject.tag == GameTags.player)
        {
            Debug.Log("Shockwave hit player");
            ObjectPool.instance.PoolObject(gameObject);
        }
    }
}
