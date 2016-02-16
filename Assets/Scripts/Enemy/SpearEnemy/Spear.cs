using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

    private Vector2 _MoveVector = new Vector2(10,0);
    private bool _InWall = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(_MoveVector * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == GameTags.player && _InWall == false)
        {
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag == GameTags.ground)
        {
            _MoveVector = new Vector2(0, 0);
            _InWall = true;
        }
    }
}
