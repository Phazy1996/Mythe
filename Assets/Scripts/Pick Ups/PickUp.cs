using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{


    public virtual void PlayerHit(PlayerMovement _SC)
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Kijkt of de collider gameObject wel de player is
        var h_Player = coll.gameObject.GetComponent<PlayerMovement>();

        //Als dit niet niet null is dan raken we de Player
        if (h_Player != null)
        {
            PlayerHit(h_Player);
        }
    }
}