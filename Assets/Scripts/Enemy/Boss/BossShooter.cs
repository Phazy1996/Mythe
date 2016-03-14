using UnityEngine;
using System.Collections;

/*
 * This script pulls the shockwaves from the object pool when its functions are called.
 * it works almost identical to the spear shooter with exept that this class puts both shockwaves (each with a diffrend tag)
 * on the screen at once.
 */

public class BossShooter : MonoBehaviour {

    public void CastShockwave()
    {
        //check what shockwave needs to be activated on which side
        if(gameObject.tag == "BossLShooter")
            ObjectPool.instance.GetObjectForType("ShockwaveL", true);
        else
            ObjectPool.instance.GetObjectForType("ShockwaveR", true);
        
    }
}
