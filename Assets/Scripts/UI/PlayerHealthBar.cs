using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    [SerializeField]
    private Image HPBar;
    [SerializeField]
    private float max_health = 100f;
    [SerializeField]
    private float cur_health = 0;

	// Use this for initialization
	void Start () {
        cur_health = max_health;
        InvokeRepeating("DecreaseHealth",0f,0.5f);
	}

    public void DecreaseHealth()
    {
        //cur_health -= 1f;
        float calc_health = cur_health / max_health;
        SetHealth(calc_health);
    }

    void SetHealth(float myHealth)
    {
        HPBar.fillAmount = myHealth;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
