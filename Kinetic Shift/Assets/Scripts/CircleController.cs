using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {

	public float maxTorque = 1000f;
	float move;

	PlayerActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = PlayerActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerActions.Jump.WasPressed)
		{
			//Jump(playerActions.Shift.IsPressed);
		}
		
		Move (playerActions.Move.Value, playerActions.Shift.IsPressed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddTorque (move * maxTorque);
	}

	void Move(float x, bool shift) {
		move = -x;
		Debug.Log (move);
	}

}
