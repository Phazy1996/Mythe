using UnityEngine;
using System.Collections;

public class Parallaxer : MonoBehaviour 
{
	public float movementSpeed;

	private ParallaxController _parallaxController;

	void Awake()
	{
		_parallaxController = GetComponent<ParallaxController> ();
	}

	void Update()
	{
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
		//transform.Translate (movement * movementSpeed * Time.deltaTime);
		_parallaxController.Scroll (movement *= -1);
	}
}
