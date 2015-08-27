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
	
	// Use this for initialization
	void Start () {
		playerActions = SpringActions.CreateWithDefaultBindings();
		
		springJointsAll = gameObject.GetComponentsInChildren<SpringJoint2D> ();
		springJointsUp = springUp.GetComponents<SpringJoint2D> ();
		springJointsDown = springDown.GetComponents<SpringJoint2D> ();
		springJointsLeft = springLeft.GetComponents<SpringJoint2D> ();
		springJointsRight = springRight.GetComponents<SpringJoint2D> ();
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

	void fixedUpdate() {

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
