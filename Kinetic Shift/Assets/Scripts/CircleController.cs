using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float jumpForce = 1f;
	float move;
	bool grounded = false;

	int currentCollisions;

	PlayerActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = PlayerActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerActions.Jump.WasPressed)
		{
			Jump(playerActions.Shift.IsPressed);
		}
		
		Move (playerActions.Move.Value, playerActions.Shift.IsPressed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddTorque (move * maxTorque);
		Debug.Log (currentCollisions);
		if (currentCollisions == 0) {
			grounded = false;
		} else {
			grounded = true;
		}
	}

	void Move(float x, bool shift) {
		move = -x;
	}

	void Jump(bool shift) {
		if (grounded)
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(){
		currentCollisions++;
	}

	void OnCollisionExit2D(){
		currentCollisions--;
	}

}
