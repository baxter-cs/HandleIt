using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public PlayerCharacter playerCharater;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (playerCharater != null && playerCharater.IsAlive()) {

			playerCharater.Move (GetInputDir(), IsPressingSprintModifierKey());

			if (Input.GetButtonDown("Jump")){
				PressedJumpButton();
			}
		}
	}
	
	void PressedJumpButton(){
		playerCharater.Jump();
	}
	public PlayerCharacter GetPlayerCharacter(){
		return playerCharater;
	}
	private Vector3 GetInputDir(){
		float x = Input.GetAxisRaw ("Horizontal");
		float y = 0;
		float z = Input.GetAxisRaw ("Vertical");
		return new Vector3(x,y,z);
	}

	private bool IsPressingSprintModifierKey() {
		return Input.GetButton ("Sprint");
	}
}
