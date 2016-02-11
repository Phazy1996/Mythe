using UnityEngine;
using System.Collections;

public class PlayerFlip : MonoBehaviour {

    //Bools
    public bool facingRight = true;
    //Bools

	void Update () 
    {
        CheckMovement();
        FlipSprite();
	}

    void CheckMovement()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (x < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
