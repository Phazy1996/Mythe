using UnityEngine;
using System.Collections;

public class HunterHealth : MonoBehaviour, IHealth {

    public delegate void HealthDepleter();
    public HealthDepleter DepleteHealth;

<<<<<<< HEAD
    private float _Health = 10;
=======
    private int _Health = 10;
>>>>>>> 13308d91e8d6a377dd9ee14e2b4df0472cb42c93

    void OnEnable()
    {
        _Health = 10;
    }

<<<<<<< HEAD
    public void ChangeHealth(float damage)
    {
        Debug.Log("HUNTER GOT HIT, changing health ");
        _Health -= damage;
=======
    public void DecreaseHealth()
    {
        Debug.Log("HUNTER GOT HIT, TAKING DAMAGE ");
        _Health -= 3;
>>>>>>> 13308d91e8d6a377dd9ee14e2b4df0472cb42c93


        if(_Health <= 0)
        {
            //send out an event when the hunters health is depleted
            if (DepleteHealth != null)
                DepleteHealth();
        }
    }

<<<<<<< HEAD
    
=======
    void Update()
    {
        Debug.Log(DepleteHealth);
    }

    public void IncreaseHealth()
    {
    }
>>>>>>> 13308d91e8d6a377dd9ee14e2b4df0472cb42c93
}
