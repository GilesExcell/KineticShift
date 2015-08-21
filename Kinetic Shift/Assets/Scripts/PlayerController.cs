﻿using UnityEngine;
using System.Collections;
using InControl;

public class PlayerController : MonoBehaviour {
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

	void Jump(bool shift) {

	};

	void Move(float x, bool shift) {

	};
}
