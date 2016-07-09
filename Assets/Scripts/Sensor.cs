using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerStay(Collider collider) {
		PlayerCharacter pc;
		GameObject go = collider.gameObject;
		pc = go.GetComponent<PlayerCharacter> ();
		if (pc.EnoughAttention()){
			print ("INTRUDER ALERT");

		}
	}

	public void OnTriggerEnter(Collider collider) {
		PlayerCharacter pc = collider.gameObject.GetComponent<PlayerCharacter> ();
		pc.InSensorRange();
	}

	public void OnTriggerExit(Collider collider) {
		PlayerCharacter pc = collider.gameObject.GetComponent<PlayerCharacter> ();
		pc.OutsideSensorRange ();
	}
}
