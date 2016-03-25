using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IHealth {

    private int _Health = 100;
    private int _MaxHealth = 100;

    public delegate void PlayerHealthDepleter();
    public PlayerHealthDepleter DepletePlayerHealth;

    void OnEnable()
    {
        _Health = 100;
    }

    public void DecreaseHealth()
    {
        _Health -= 25;

        if(_Health <= 0)
        {
            Debug.Log("HOMER IS DEAD");
            if(DepletePlayerHealth != null)
            {
                DepletePlayerHealth();
            }
        }
    }

    public void IncreaseHealth()
    {
        _Health += 25;
        //return health to 100 if it goes higher
        if(_Health > _MaxHealth)
        {
            _Health = 100;
        }
    }
}
