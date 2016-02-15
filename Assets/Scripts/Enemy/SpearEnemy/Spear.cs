using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector2(10, 0) * Time.deltaTime);
	}
}
