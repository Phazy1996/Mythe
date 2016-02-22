using UnityEngine;
using System.Collections;

public class SonCollectable : Pickup
{
    //Int
    private int _secondsBeforeDisappearing;
    //Int

    //Float
    private float _collectableCount;
    //Float


    public override void PlayerHit(PlayerMovement _SC)
    {
        StartCoroutine("RemoveSon");
        base.PlayerHit(_SC);
    }

    private IEnumerator RemoveSon()
    {
        _secondsBeforeDisappearing = 1;
        yield return new WaitForSeconds(_secondsBeforeDisappearing);
        _collectableCount += 1;
            Destroy(this.gameObject);

    }
}