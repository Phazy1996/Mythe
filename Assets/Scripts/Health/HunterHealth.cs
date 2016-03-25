using UnityEngine;
using System.Collections;

public class HunterHealth : MonoBehaviour, IHealth {

    public delegate void HealthDepleter();
    public HealthDepleter DepleteHealth;

    private int _Health = 10;

    void OnEnable()
    {
        _Health = 10;
    }

    public void DecreaseHealth()
    {
        Debug.Log("HUNTER GOT HIT, TAKING DAMAGE ");
        _Health -= 3;


        if(_Health <= 0)
        {
            //send out an event when the hunters health is depleted
            if (DepleteHealth != null)
                DepleteHealth();
        }
    }

    void Update()
    {
        Debug.Log(DepleteHealth);
    }

    public void IncreaseHealth()
    {
    }
}
