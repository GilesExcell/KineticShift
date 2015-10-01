using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float maxGroundForce = 1f;
	public float maxAirForce = 1f;
	public float jumpForce = 5f;
	public float jumpTime = 0.1f;
	public float drainRate = 0.5f;
	public float storedEnergy { get; private set; }

	float move;
	bool grounded = false;

	float jump = 0.0f;
	Vector2 direction;
	Rigidbody2D body;
	float shiftImpulse;
	Vector2 lastVelocity = Vector2.zero;


	int currentCollisions;

	BallActions playerActions;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		playerActions = BallActions.CreateWithDefaultBindings();
		storedEnergy = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerActions.Jump.WasPressed)
		{
			Jump(playerActions.JumpDirection.Value);
		}
		if (playerActions.Brake.IsPressed){
			Brake();
		}else{
			Move (playerActions.Move.Value, playerActions.Shift.IsPressed);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (body.velocity.sqrMagnitude < lastVelocity.sqrMagnitude) {
			storedEnergy += body.mass * (body.velocity - lastVelocity).sqrMagnitude / 2.0f;
		}
		Debug.Log (storedEnergy, gameObject);


		body.AddTorque (move * maxTorque);
		if (currentCollisions == 0) {
			grounded = false;
		} else {
			grounded = true;
		}
		currentCollisions = 0;

		if (grounded) {
			body.AddForce (move * maxGroundForce * Vector2.left);

			if (jump > 0) {
				jump = 0.0f;

				storedEnergy += body.mass * (body.velocity).sqrMagnitude / 2.0f;
				body.velocity = Vector2.zero;
				lastVelocity = Vector2.zero;

				shiftImpulse = jumpForce + Mathf.Sqrt(storedEnergy);
				storedEnergy = 0;
				body.AddForce(direction * shiftImpulse, ForceMode2D.Impulse);
			}
		} else {
			body.AddForce (move * maxAirForce * Vector2.left);
		}

		jump -= Time.deltaTime;
		lastVelocity = body.velocity;

		if (storedEnergy > 0) {
			storedEnergy *= (1 - Time.deltaTime * drainRate);
		}

		if (storedEnergy < 0) {
			storedEnergy = 0;
		}
	}

	void Move(float x, bool shift) {
		move = -x;
	}

	void Brake(){
		//GetComponent<Rigidbody2D> ().AddTorque (-10);

	}

	void Jump(Vector2 dir) {
		if (dir != Vector2.zero) {
			jump = jumpTime;
			direction = dir.normalized;

		}
	}

	void OnCollisionStay2D(){
		currentCollisions++;
	}

	void OnCollisionExit2D(){
		currentCollisions--;
	}
}
