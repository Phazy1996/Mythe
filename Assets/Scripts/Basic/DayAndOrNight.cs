using UnityEngine;

using System.Collections;
public class DayAndOrNight : MonoBehaviour {


    public bool _dayLight = false;
    public bool _nightLight = false;

    private GameObject _mainCamObject;
    private Camera _mainCam;

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
