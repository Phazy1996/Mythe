using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpearShooter : MonoBehaviour {

    [SerializeField]
    private GameObject _Spear;

    private int _ShotCoolDown = 50;

    public enum Projectile
    {
        spear
    }
    public Dictionary<Projectile, GameObject> shooter = new Dictionary<Projectile, GameObject>();
    private Projectile _Projectiles;

	void Start () 
    {
        shooter.Add(Projectile.spear, _Spear);
	}

    void Update()
    {
        Physics.IgnoreLayerCollision(9, 11, true);
        _ShotCoolDown--;
        if (_ShotCoolDown < 0)
            _ShotCoolDown = 0;

    }

    public void ThrowSpear()
    {
        if(_ShotCoolDown == 0)
        {
            var _ThrowSpear = (GameObject)Instantiate(shooter[_Projectiles], transform.position, transform.rotation);
            _ShotCoolDown = 100;
        }
            
    }
}
