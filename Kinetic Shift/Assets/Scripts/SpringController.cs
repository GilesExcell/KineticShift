using UnityEngine;
using System.Collections;
using InControl;

public class SpringController : MonoBehaviour {
	SpringActions playerActions;
	public GameObject Spring1;
	public GameObject Spring2;
	public GameObject Spring3;
	public GameObject Spring4;
	public float lowFrequency;
	public float highFrequency;
	public float springDistance;
	
	// Use this for initialization
	void Start () {
		playerActions = SpringActions.CreateWithDefaultBindings();
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

	void ResetForInput(){
		Spring1.GetComponent<SpringJoint2D> ().distance = 0.05f;
		Spring2.GetComponent<SpringJoint2D> ().distance = 0.05f;
		Spring3.GetComponent<SpringJoint2D> ().distance = 0.05f;
		Spring4.GetComponent<SpringJoint2D> ().distance = 0.05f;
		Spring1.GetComponent<SpringJoint2D> ().frequency = lowFrequency;
		Spring2.GetComponent<SpringJoint2D> ().frequency = lowFrequency;
		Spring3.GetComponent<SpringJoint2D> ().frequency = lowFrequency;
		Spring4.GetComponent<SpringJoint2D> ().frequency = lowFrequency;

	}

	void Up() {
		Spring3.GetComponent<SpringJoint2D> ().distance = springDistance;
	}
	
	void Down() {
		Spring1.GetComponent<SpringJoint2D> ().distance = springDistance;
	}

	void Left() {
		Spring4.GetComponent<SpringJoint2D> ().distance = springDistance;
	}

	void Right() {
		Spring2.GetComponent<SpringJoint2D> ().distance = springDistance;
	}

	void Shift() {
		
		Spring1.GetComponent<SpringJoint2D> ().frequency = highFrequency;
		Spring2.GetComponent<SpringJoint2D> ().frequency = highFrequency;
		Spring3.GetComponent<SpringJoint2D> ().frequency = highFrequency;
		Spring4.GetComponent<SpringJoint2D> ().frequency = highFrequency;
	}
}
