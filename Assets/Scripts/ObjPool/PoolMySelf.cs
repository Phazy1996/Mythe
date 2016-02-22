using UnityEngine;
using System.Collections;

public class PoolMySelf : MonoBehaviour {

	private int timer = 0;

	void OnEnable()
	{
		timer = 0;
	}

	void OnDisable() 
	{
		this.transform.position = new Vector3 (0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		timer++;
		this.transform.Translate (Vector3.up);
		if (timer >= 20) {
			ObjectPool.instance.PoolObject (gameObject);
		}
	}
}
