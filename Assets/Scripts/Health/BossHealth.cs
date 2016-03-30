using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour, IHealth {

    public delegate void BossHealthDepleter();
    public BossHealthDepleter _DepleteBossHealth;

    private int _Health = 1000;

    void OnEnable()
    {
        _Health = 1000;
    }

	public void DecreaseHealth()
    {
        _Health -= 75;

        if(_Health <= 0)
        {
            if(_DepleteBossHealth != null)
                _DepleteBossHealth();
        }
    }

    public void IncreaseHealth()
    {

    }
}
