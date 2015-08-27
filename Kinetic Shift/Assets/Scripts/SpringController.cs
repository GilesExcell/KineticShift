using UnityEngine;
using System.Collections;
using InControl;

public class SpringController : MonoBehaviour {
	SpringActions playerActions;
	public GameObject springUp;
	public GameObject springDown;
	public GameObject springLeft;
	public GameObject springRight;
	public float lowFrequency;
	public float highFrequency;
	public float lowDistance;
	public float springDistance;

	SpringJoint2D[] springJointsAll;
	SpringJoint2D[] springJointsUp;
	SpringJoint2D[] springJointsDown;
	SpringJoint2D[] springJointsLeft;
	SpringJoint2D[] springJointsRight;

	float mass;
	float springUpMass;
	float springDownMass;
	float springLeftMass;
	float springRightMass;
	
	// Use this for initialization
	void Start () {
		playerActions = SpringActions.CreateWithDefaultBindings();
		
		springJointsAll = gameObject.GetComponentsInChildren<SpringJoint2D> ();
		springJointsUp = springUp.GetComponents<SpringJoint2D> ();
		springJointsDown = springDown.GetComponents<SpringJoint2D> ();
		springJointsLeft = springLeft.GetComponents<SpringJoint2D> ();
		springJointsRight = springRight.GetComponents<SpringJoint2D> ();
		
		mass = gameObject.GetComponent<Rigidbody2D> ().mass;
		springUpMass = springUp.GetComponent<Rigidbody2D> ().mass;
		springDownMass = springDown.GetComponent<Rigidbody2D> ().mass;
		springLeftMass = springLeft.GetComponent<Rigidbody2D> ().mass;
		springRightMass = springRight.GetComponent<Rigidbody2D> ().mass;
	}
	
	// Update is called once per frame
	void Update () {
		ResetForInput();
		if (playerActions.Up.IsPressed)
		{
			Up();
		}
		if (playerActions.Down.IsPressed)
		{
			Down();
		}
		if (playerActions.Left.IsPressed)
		{
			Left();
		}
		if (playerActions.Right.IsPressed)
		{
			Right();
		}
		if (playerActions.Shift.IsPressed)
		{
			Shift();
		}
	}

	void FixedUpdate() {
		Vector2 centerOfMass = gameObject.transform.position * mass
							+ springUp.transform.position * springUpMass
							+ springDown.transform.position * springDownMass
							+ springLeft.transform.position * springLeftMass
							+ springRight.transform.position * springRightMass;
		centerOfMass = centerOfMass / (mass + springUpMass + springDownMass + springLeftMass + springRightMass);
		centerOfMass -= (Vector2)gameObject.transform.position;
		gameObject.GetComponent<Rigidbody2D> ().centerOfMass = centerOfMass;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawIcon (transform.position + (Vector3)gameObject.GetComponent<Rigidbody2D> ().centerOfMass, "CoM");
	}

	void ResetForInput(){
		foreach (SpringJoint2D spring in springJointsAll) {
			spring.distance = lowDistance;
			spring.frequency = lowFrequency;
		}
	}

	void Up() {
		foreach (SpringJoint2D spring in springJointsUp) {
			spring.distance = springDistance;
		}
	}
	
	void Down() {
		foreach (SpringJoint2D spring in springJointsDown) {
			spring.distance = springDistance;
		}
	}

	void Left() {
		foreach (SpringJoint2D spring in springJointsLeft) {
			spring.distance = springDistance;
		}
	}

	void Right() {
		foreach (SpringJoint2D spring in springJointsRight) {
			spring.distance = springDistance;
		}
	}

	void Shift() {
		foreach (SpringJoint2D spring in springJointsAll) {
			spring.frequency = highFrequency;
		}
	}
}
