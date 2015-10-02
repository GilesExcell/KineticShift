using UnityEngine;
using System.Collections;

public class LvlSelectController : MonoBehaviour {

	// Returns to the main menu
	public void Back()
	{
		Application.LoadLevel (0);
	}

	public void LoadLevel(string level)
	{
		Application.LoadLevel (level);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
