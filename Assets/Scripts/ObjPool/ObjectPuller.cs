using UnityEngine;
using System.Collections;

public class ObjectPuller : MonoBehaviour {


	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ObjectPool.instance.GetObjectForType ("Sphere", true);
		}
	}
}
