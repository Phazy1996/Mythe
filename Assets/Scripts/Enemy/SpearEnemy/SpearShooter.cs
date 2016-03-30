using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This script pulls the spears from the object pool when its functions are called
 * it has a diffrend function for both the left and right side, each of wich spawns a spear with a diffrend tag.
 * through the tag the spear can work out wich way it needs to go and face.
 */

public class SpearShooter : MonoBehaviour {

    public void ThrowSpear(bool _FacingRight)
    {
<<<<<<< HEAD
        if (_FacingRight == true)
=======
        Physics.IgnoreLayerCollision(9, 11, true);
        _ShotCoolDown--;
        if (_ShotCoolDown < 0)
            _ShotCoolDown = 0;
    }

    public void ThrowSpearR()
    {
        if(_ShotCoolDown == 0)
>>>>>>> parent of 13308d9... added health, tweaked hunter, added bossDeathState
        {
            ObjectPool.instance.GetObjectForType("SpearR", true);
        }
        else if (_FacingRight == false)
        {
            ObjectPool.instance.GetObjectForType("SpearL", true);
        }
    }
}
