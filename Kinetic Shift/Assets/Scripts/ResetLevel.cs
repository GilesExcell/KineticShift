using UnityEngine;
using System.Collections;
using InControl;

public class ResetLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		InputDevice device = InputManager.ActiveDevice;
		if (device.MenuWasPressed) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
}
