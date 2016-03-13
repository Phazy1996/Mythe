using UnityEngine;
using System.Collections;

public class ShockWave : MonoBehaviour {

    private bool _IsLeftShockwave;
    private Vector2 _WaveMoveVector = new Vector2(5,0);

	void Start () 
    {
        CheckSide();
	}
	

	void Update () 
    {
	
	}

    void CheckSide()
    {
        //check what side shockwave is on.
        if (gameObject.tag == "ShockL")
            _IsLeftShockwave = true;
        else
            _IsLeftShockwave = false;
    }

    void MoveWave()
    {
        if (_IsLeftShockwave)
            //move shockwave left
            transform.Translate(-_WaveMoveVector * Time.deltaTime);
        else
            //move shockwave right
            transform.Translate(_WaveMoveVector * Time.deltaTime);
    }
}
