using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

    private Vector2 _MoveVector = new Vector2(10,0);
    private bool _InWall = false;
    private Vector2 _NullVector = new Vector2(0,0);
    private Vector2 _Scale;
    //public bool _FacingRight = true;

    void Start()
    {
        if(gameObject.tag == "SpearLeft")
        {
            Debug.Log("Spear goes left");
            _MoveVector = new Vector2(-10,0);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

	void Update () 
    {
        transform.Translate(_MoveVector * Time.deltaTime);
	}

    void OnCollisionStay2D(Collision2D coll)
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
}