using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {
	public float speed = 2.5f;
	public float jitter = 5.0f;
	public Vector3 startPos;
	public Vector3 moveDir = Vector3.zero;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 delta = (startPos - transform.position);
		moveDir += Get2dRandom() * (Time.deltaTime * jitter);
		transform.position += moveDir * (Time.deltaTime * speed) +Time.deltaTime * delta / 2;
	}

	private Vector3 Get2dRandom() {
		Vector2 rand = Random.insideUnitCircle;
		rand = new Vector3 (rand.x, 0, rand.y);
		return rand;

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
