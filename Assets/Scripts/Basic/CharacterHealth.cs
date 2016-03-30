using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public delegate void HealthDelegate(int num);
    public HealthDelegate _HealthDelegate;

    void TakeDamage(int _Damage)
    {
        _HealthDelegate = TakeDamage;
        _HealthDelegate(_Damage);
    }

    void RecoverDamage(int _Damage)
    {
        _HealthDelegate = RecoverDamage;
        _HealthDelegate(_Damage);
    }
}
