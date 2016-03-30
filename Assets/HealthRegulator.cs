using UnityEngine;
using System.Collections;

public class HealthRegulator : MonoBehaviour {
    //floats
    [SerializeField]
    private float _health;
    //floats
    private PlayerAttack _playerAtack;

    void Awake()
    {
        _playerAtack = GameObject.Find(GameTags.player).GetComponent<PlayerAttack>();

    }
    public void HealthChange(float amount) {
        Debug.Log(this.gameObject.name + " health changed");
        _health = _health - amount;
    }
    //use this function to start the function written by jochem
    public void StartDamageTaking()
    {
        StartCoroutine(GetHit());
        Debug.Log("how2delegates");
    }
    private IEnumerator GetHit()
    {
        while(_playerAtack.atackIsDone == false)
        {
            Debug.Log("gaande");
            _playerAtack.damageEnemy += HealthChange;
            yield return new WaitForFixedUpdate();
            _playerAtack.dealingDamage = true;
            _playerAtack.atackIsDone = true;
            yield return null;
            
        }
       
        _playerAtack.damageEnemy -= HealthChange;
        _playerAtack.atackIsDone = true;
    }
    void Update() {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
