using UnityEngine;
using System.Collections;

public class LvlSelectController : MonoBehaviour {

	public int LevelToLoad;

	// Returns to the main menu
	public void Back()
	{
		Application.LoadLevel (0);
	}

	public void LoadLevel()
	{
		Application.LoadLevel (LevelToLoad);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
