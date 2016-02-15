using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpearShooter : MonoBehaviour {

    [SerializeField]
    private GameObject _Spear;

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

    public void ThrowSpear()
    {
        var _ThrowSpear = (GameObject)Instantiate(shooter[_Projectiles], transform.position, transform.rotation);
    }

    public void ThrowSpearL()
    {
        var _ThrowSpear = (GameObject)Instantiate(shooter[_Projectiles], transform.position, Quaternion.identity);
    }
}
