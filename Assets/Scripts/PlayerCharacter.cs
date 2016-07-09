using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

	Rigidbody phys;
	public float jumpForce = 15.0f;
	public float walkingSpeed = 10.0f;
	public float runningSpeed = 20.0f;
	public static int staminaCap = 100;
	public int stamina = staminaCap;
	private bool isSprinting;

	// Use this for initialization
	void Start () {
		phys = GetComponent<Rigidbody> ();
	}

	void Update () {

	}

	public void Move(Vector3 dir, bool sprinting) {
		Vector3 jumpVel = Vector3.up * phys.velocity.y;
		phys.velocity = UpdateSpeed (sprinting) * dir + jumpVel;
	}

	public void Jump() {
		phys.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
	}

	private float UpdateSpeed (bool sprinting) {
		if (sprinting && (stamina > 0)) {
			stamina -= 3;
			isSprinting = true;
			return runningSpeed;
		} else {
			stamina += stamina < staminaCap ? 1 : 0;
			isSprinting = false;
			return walkingSpeed;
		}
	}

	public bool IsSprinting() {
		return isSprinting;
	}

	public bool IsAlive() {
		return true;
	}
}
