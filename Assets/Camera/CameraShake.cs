using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private float shakePower = 0.7f;
    private float duration = 0.5f;
    private bool isShaking = false;
	
	void Update () 
    {
        //shake camera
        if(isShaking)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakePower;
        }
	}

    //allow camera shaking
    public void Shake()
    {
        isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    //disallow camera shaking
    public void StopShaking()
    {
        isShaking = false;
    }
}
