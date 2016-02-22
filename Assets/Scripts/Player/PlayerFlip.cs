using UnityEngine;
using System.Collections;

public class PlayerFlip : MonoBehaviour {

    //Bools
    public bool _facingRight = true;
    //Bools
    void Start() {
        _facingRight = this.gameObject.GetComponent<PlayerFlip>();
    }
    void Update () 
    {
        CheckMovement();
        FlipSprite();
	}

    void CheckMovement()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0 && !_facingRight)
        {
            FlipSprite();
        }
        else if (x < 0 && _facingRight)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
