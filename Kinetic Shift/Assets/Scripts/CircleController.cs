using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1f;
	public float jumpForce = 1f;
	float move;
	bool grounded = false;
	
	public Text KEText;
	int kineticEnergy;

	int currentCollisions;

	BallActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = BallActions.CreateWithDefaultBindings();
		kineticEnergy = 0;
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
		Debug.Log (currentCollisions);
		if (currentCollisions == 0) {
			grounded = false;
		} else {
			grounded = true;
		}
	}

	void Move(float x, bool shift) {
		move = -x;

		if (shift) {
			kineticEnergy -= 1;
			SetEnergySlider();
		} else {
			kineticEnergy += 1;
			SetEnergySlider();
		}
	}

	void Brake(){
		//GetComponent<Rigidbody2D> ().AddTorque (-10);

	}

	void Jump(Vector2 direction, bool shift) {
		if (grounded){
			GetComponent<Rigidbody2D> ().AddForce (direction * jumpForce, ForceMode2D.Impulse);
			
			if (shift) {
			kineticEnergy -= 1;
			} else {
			kineticEnergy += 1;
			}
			//SetEnergySlider();
		}
	}

	void OnCollisionEnter2D(){
		currentCollisions++;
	}

	void OnCollisionExit2D(){
		currentCollisions--;
	}

	void SetEnergySlider (){
		KEText.text = "Kinetic Energy: " + kineticEnergy.ToString();

		if (kineticEnergy < 0){
			kineticEnergy = 0;
		} else if (kineticEnergy > 100){
			kineticEnergy = 100;
		}
	}

}
