using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float jumpForce = 1f;
	public float shiftForce;
	public float shiftGeneration;
	public float shiftConversion;
	float move;
	bool grounded = false;
	float energy = 5f;

	int currentCollisions;

	BallActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = BallActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {

		//if (playerActions.Brake.IsPressed){
		//	Brake();
		//}else{
		Move (playerActions.Move.Value, playerActions.Shift.IsPressed);
		//}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddTorque (move * maxTorque);
		if (currentCollisions == 0) {
			grounded = false;
		} else {
			grounded = true;
		}
		if (!playerActions.Jump.IsPressed && energy < 10){
			energy ++;
		}
		if (playerActions.Jump.WasReleased)
		{
			Jump(playerActions.JumpDirection.Value, playerActions.Shift.IsPressed);
		}
		if (playerActions.Jump.IsPressed) {
			if (energy > 0){
				shiftForce += shiftGeneration;
				energy-= shiftConversion;
				Debug.Log (shiftForce);
				}
		}
	}

	void Move(float x, bool shift) {
		move = -x;
	}

	void Brake(){
		//GetComponent<Rigidbody2D> ().AddTorque (-10);

	}

	void Jump(Vector2 direction, bool shift) {
		if (grounded) {
			GetComponent<Rigidbody2D> ().AddForce (direction * shiftForce, ForceMode2D.Impulse);
			shiftForce = 0;

		}
	}

	void OnCollisionEnter2D(){
		currentCollisions++;
	}

	void OnCollisionExit2D(){
		currentCollisions--;
	}

}
