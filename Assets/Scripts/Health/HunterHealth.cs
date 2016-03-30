using UnityEngine;
using System.Collections;

public class HunterHealth : MonoBehaviour, IHealth {

    public delegate void HealthDepleter();
    public HealthDepleter DepleteHealth;

    private float _Health = 10;

    void OnEnable()
    {
        _Health = 10;
    }

    public void ChangeHealth(float damage)
    {
        Debug.Log("HUNTER GOT HIT, changing health ");
        _Health -= damage;


        if(_Health <= 0)
        {
            //send out an event when the hunters health is depleted
            if (DepleteHealth != null)
                DepleteHealth();
        }
    }

    
}
