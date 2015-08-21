using UnityEngine;
using System.Collections;
using InControl;

public class SpringController : MonoBehaviour {
	SpringActions playerActions;
	
	// Use this for initialization
	void Start () {
		playerActions = SpringActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerActions.Up.WasPressed)
		{
			Up(playerActions.Shift.IsPressed);
		}
		if (playerActions.Down.WasPressed)
		{
			Down(playerActions.Shift.IsPressed);
		}
		if (playerActions.Left.WasPressed)
		{
			Left(playerActions.Shift.IsPressed);
		}
		if (playerActions.Right.WasPressed)
		{
			Right(playerActions.Shift.IsPressed);
		}


	}
	
	void Up(bool shift) {
		// pop top panel
	}
	
	void Down(bool shift) {
		// pop down panel
	}

	void Left(bool shift) {
		// pop left panel
	}

	void Right(bool shift) {
		// pop right panel
	}
}
