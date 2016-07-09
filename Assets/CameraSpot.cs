using UnityEngine;
using System.Collections;

public class CameraSpot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LookAtPoint(Vector3 target) {
		Vector3 delta = target - transform.position;
		Quaternion rotation = Quaternion.LookRotation (delta);
		transform.rotation = rotation;
	}

}
