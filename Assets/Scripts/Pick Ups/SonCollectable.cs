using UnityEngine;
using System.Collections;


public class SonCollectable : Pickup
{
    //Int
    private int _secondsBeforeDisappearing;
    //Int

    //Bool
    public bool addSon = false;
    //Bool

    public override void PlayerHit(PlayerMovement _SC)
    {
        StartCoroutine("RemoveSon");
        base.PlayerHit(_SC);
    }

    private IEnumerator RemoveSon()
    {
        _secondsBeforeDisappearing = 1;
      
        yield return new WaitForSeconds(_secondsBeforeDisappearing);


        addSon = true;
        Destroy(this.gameObject);

    }
}