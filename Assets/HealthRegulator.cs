using UnityEngine;
using System.Collections;

public class HealthRegulator : MonoBehaviour {
    //floats
    [SerializeField]
    private float _health;
    //floats



    public void HealthChange(float amount) {
        _health = _health + amount;
    }

    void Update() {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
