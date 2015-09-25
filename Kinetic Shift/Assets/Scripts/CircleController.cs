using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float jumpForce = 5f;
	public float jumpTime = 0.1f;
	public float drainRate = 0.5f;
	public Slider energySlider;
	float move;
	bool grounded = false;

	
	public Text KEText;
	int kineticEnergy;

	float jump = 0.0f;
	Vector2 direction;
	Rigidbody2D body;
	float shiftImpulse;
	public float storedEnergy { get; private set; }
	Vector2 lastVelocity = Vector2.zero;


	int currentCollisions;

	BallActions playerActions;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		playerActions = BallActions.CreateWithDefaultBindings();

		kineticEnergy = 0;
		SetEnergy();

		setEnergyBar ();

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
		setEnergyBar ();
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

		if (grounded && jump > 0) {
			jump = 0.0f;
			shiftImpulse = jumpForce + Mathf.Sqrt(storedEnergy);
			storedEnergy = 0;
			body.AddForce(direction * shiftImpulse, ForceMode2D.Impulse);
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
		Debug.Log("Move: " + move);

		if (shift) {
			kineticEnergy -= 10;
			SetEnergy();
		} else if (move != 0){
			kineticEnergy += 1;
			SetEnergy();
		}
	}

	void Brake(){
		//GetComponent<Rigidbody2D> ().AddTorque (-10);

	}


	void Jump(Vector2 direction, bool shift) {
		if (grounded) {
			GetComponent<Rigidbody2D> ().AddForce (direction * jumpForce, ForceMode2D.Impulse);
			
			if (shift) {
				kineticEnergy -= 100;
				SetEnergy ();
			} else {
				kineticEnergy += 1;
			}
			//SetEnergySlider();
		}
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


	void SetEnergy (){

		if (kineticEnergy < 0) {
			kineticEnergy = 0;
		} else if (kineticEnergy > 1000) {
			kineticEnergy = 1000;
		}

		KEText.text = "Kinetic Energy: " + kineticEnergy.ToString ();
	}

	void setEnergyBar(){
		energySlider.value = storedEnergy;

	}

}
