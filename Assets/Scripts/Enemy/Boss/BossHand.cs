using UnityEngine;
using System.Collections;

public class BossHand : MonoBehaviour {

    private bool _IsLeftHand;
    private Vector2 _HandPos2D;

    public Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

	void Start () 
    {
        if (gameObject.tag == "BossLeftHand")
            _IsLeftHand = true;
        else
            _IsLeftHand = false;

        _HandPos2D = new Vector2(transform.position.x, transform.position.y);

        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, endMarker);
	}
	
	void Update () 
    {
        Idle();
	}

    void Idle()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        Vector3 _HandPos = transform.position;
        //transform.position = (Random.insideUnitCircle * 1) + _HandPos2D;
        Vector3 endMarker = (Random.insideUnitCircle * 1) + _HandPos2D;

        transform.position = Vector3.Lerp(transform.position, endMarker, fracJourney);
    }

    void Smash ()
    {
        
    }
}
