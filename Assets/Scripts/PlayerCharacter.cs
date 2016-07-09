using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

	Rigidbody phys;
	public float jumpForce = 15.0f;
	public float walkingSpeed = 10.0f;
	public float runningSpeed = 20.0f;
	public float attentionRate = 0.0f;
	public static int walkStamina = 3;
	public static int runStamina = 0;
	public static int stationaryStamina = 1;
	public static float walkAttention = 0.01f;
	public static float runAttention = 0.03f;
	public static float jumpAttention = 0.05f;
	public static float stationaryAttention = -0.02f;
	public static int staminaCap = 100;
	public static float sensorAttentionThreshold = 0.47f;
	public int stamina = staminaCap;
	public float deadMove = 0.01f;
	private bool isSprinting;
	public int sensorsInRange;

	// Use this for initialization
	void Start () {
		phys = GetComponent<Rigidbody> ();
	}

	void Update () {

	}

	public void Move(Vector3 dir, bool sprinting) {
		Vector3 jumpVel = Vector3.up * phys.velocity.y;
		if (dir.sqrMagnitude <= deadMove) {
			phys.velocity = Vector3.zero + jumpVel;
			ChangeAttention (stationaryAttention);
		} else {
			phys.velocity = UpdateSpeed (sprinting) * dir + jumpVel;
		}
	}

	public void Jump() {
		phys.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		ChangeAttention (jumpAttention);
	}

	private float UpdateSpeed (bool sprinting) {
		if (sprinting && (stamina > 0)) {
			return UpdateRun ();
		} else {
			return UpdateWalk ();
		}
	}

	private float UpdateRun() {
		stamina -= runStamina;
		ChangeAttention (runAttention);
		isSprinting = true;
		return runningSpeed;
	}

	private float UpdateWalk() {
		stamina += stamina < staminaCap ? stationaryStamina : 0;
		stamina -= walkStamina;
		isSprinting = false;
		ChangeAttention (walkAttention);
		return walkingSpeed;
	}

	public bool IsSprinting() {
		return isSprinting;
	}

	public bool IsAlive() {
		return true;
	}

	public float ChangeAttention(float delta) {
		if (sensorsInRange > 0) {
			attentionRate += delta;
			attentionRate = Mathf.Clamp01 (attentionRate);
			return attentionRate;
		} else if (delta < 0) {
			attentionRate += delta;
			attentionRate = Mathf.Clamp01 (attentionRate);
			return attentionRate;
		} else {
			return attentionRate;
		}
	}

	public bool EnoughAttention() {
		return sensorAttentionThreshold < attentionRate;
	}

	public void InSensorRange() {
		sensorsInRange++;
	}

	public void OutsideSensorRange() {
		sensorsInRange--;
	}
}
