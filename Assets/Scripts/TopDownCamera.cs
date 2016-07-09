using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour {

	Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("GameState").GetComponent<Player> ();;

	}

	// Update is called once per frame
	void Update () {
		PlayerCharacter pc = player.GetPlayerCharacter ();
		Vector3 target = Vector3.zero;
		if (pc) {
			target = pc.transform.position;
		}

		MoveTowardsTarget (target);
	}

	public void MoveTowardsTarget(Vector3 target) {
		Vector3 delta = target - transform.position;
		delta = new Vector3 (delta.x, 0, delta.z);
		if (delta.magnitude > 7) {
			transform.position += delta / 40;
		} else {
			transform.position += delta / 90;
		}
	}
}
