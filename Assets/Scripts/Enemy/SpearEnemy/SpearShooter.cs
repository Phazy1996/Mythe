using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This script pulls the spears from the object pool when its functions are called
 * it has a diffrend function for both the left and right side, each of wich spawns a spear with a diffrend tag.
 * through the tag the spear can work out wich way it needs to go and face.
 */

public class SpearShooter : MonoBehaviour {
    private int _ShotCoolDown = 50;

    void Update()
    {
        Physics.IgnoreLayerCollision(9, 11, true);
        _ShotCoolDown--;
        if (_ShotCoolDown < 0)
            _ShotCoolDown = 0;
    }

    public void ThrowSpearR()
    {
        if(_ShotCoolDown == 0)
        {
            ObjectPool.instance.GetObjectForType("SpearR", true);
            _ShotCoolDown = 100;
        }     
    }

    public void ThrowSpearL()
    {
        if (_ShotCoolDown == 0)
        {
            ObjectPool.instance.GetObjectForType("SpearL", true);
            _ShotCoolDown = 100;
        }     
    }
}
