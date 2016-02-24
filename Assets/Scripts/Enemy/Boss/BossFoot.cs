using UnityEngine;
using System.Collections;

public class BossFoot : MonoBehaviour {


    private bool _IsLeftHand;
	void Start () 
    {
        //determine what foot this is
	    if(gameObject.tag == "BossLeftFoot")
            _IsLeftHand = true;
        else
            _IsLeftHand = false;
	}
	
	void Update () 
    {
	    
	}

    void Step ()
    {

    }
}
