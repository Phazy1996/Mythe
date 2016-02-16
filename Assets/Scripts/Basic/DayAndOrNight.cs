using UnityEngine;

using System.Collections;
public class DayAndOrNight : MonoBehaviour {


    //Bools
    public bool _dayLight = false;
    public bool _nightLight = false;
    //Bools

    //GameObject
    private GameObject _mainCamObject;
    //GameObject

    //Camera
    private Camera _mainCam;
    //Camera

	void Start () 
    {
        _mainCamObject = GameObject.FindGameObjectWithTag(GameTags.maincamera);
        _mainCam = _mainCamObject.GetComponent<Camera>();
	}
	
	void Update () 
    {
        TurnDayLightOn();
        TurnNightLightOn();
	}

    private void TurnNightLightOn()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _mainCam.backgroundColor = Color.clear;
        }
    }

    private void TurnDayLightOn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _mainCam.backgroundColor = Color.white;
        }
    }
}
