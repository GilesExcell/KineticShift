using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float jumpForce = 1f;
	float move;
	bool grounded = false;

	int currentCollisions;

	BallActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = BallActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerActions.Jump.WasPressed)
		{
			Jump(playerActions.JumpDirection.Value, playerActions.Shift.IsPressed);
		}
		if (playerActions.Brake.IsPressed){
			Brake();
		}else{
		Move (playerActions.Move.Value, playerActions.Shift.IsPressed);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddTorque (move * maxTorque);
		if (currentCollisions == 0) {
			grounded = false;
		} else {
			grounded = true;
		}
	}

	void Move(float x, bool shift) {
		move = -x;
	}

	void Brake(){
		//GetComponent<Rigidbody2D> ().AddTorque (-10);

	}

	void Jump(Vector2 direction, bool shift) {
		if (grounded)
			GetComponent<Rigidbody2D> ().AddForce (direction * jumpForce, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(){
		currentCollisions++;
	}

	void OnCollisionExit2D(){
		currentCollisions--;
	}

}
