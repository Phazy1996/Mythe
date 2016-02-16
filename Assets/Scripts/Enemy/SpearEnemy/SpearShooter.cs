using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpearShooter : MonoBehaviour {

    [SerializeField]
    private GameObject _Spear;
    private Vector2 _LeftSpearScale;
    private int _ShotCoolDown = 50;
    private Spear _ThrownSpear;

    //Enum with spear (and possibly other projectiles) in it.
    public enum Projectile
    {
        spear
    }
    //dictionary containing the projectiles the enemy can throw
    public Dictionary<Projectile, GameObject> shooter = new Dictionary<Projectile, GameObject>();
    private Projectile _Projectiles;

	void Start () 
    {
        //add spear from projectile enum to dictionary
        shooter.Add(Projectile.spear, _Spear);

        _ThrownSpear = _Spear.GetComponent<Spear>();
	}

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
            var _ThrowSpear = (GameObject)Instantiate(shooter[_Projectiles], transform.position, Quaternion.identity);
            //_ThrownSpear._FacingRight = true;
            _ShotCoolDown = 100;
        }    
    }

    public void ThrowSpearL()
    {
        if (_ShotCoolDown == 0)
        {
            var _ThrowSpear = (GameObject)Instantiate(shooter[_Projectiles], transform.position, Quaternion.identity);
            //set thrown spear scale to negative on X axis to make it turn the correct direction
            //_ThrowSpear.transform.localScale = new Vector2(-_ThrowSpear.transform.localScale.x, _ThrowSpear.transform.localScale.y);
            //_ThrownSpear._FacingRight = false;
            _ShotCoolDown = 100;
        }
    }
}
