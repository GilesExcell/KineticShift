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
		if (device.Action2.WasPressed || Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		} if (device.MenuWasPressed || Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel ("LevelSelect");
		}
	}
}
