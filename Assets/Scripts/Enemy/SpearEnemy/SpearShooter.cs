using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This script pulls the spears from the object pool when its functions are called
 * it has a diffrend function for both the left and right side, each of wich spawns a spear with a diffrend tag.
 * through the tag the spear can work out wich way it needs to go and face.
 */

public class SpearShooter : MonoBehaviour
{

    public void ThrowSpear(bool _FacingRight)
    {
        if (_FacingRight == true)
        {
            ObjectPool.instance.GetObjectForType("SpearR", true);
        }
        else if (_FacingRight == false)
        {
            ObjectPool.instance.GetObjectForType("SpearL", true);
        }
    }
}
