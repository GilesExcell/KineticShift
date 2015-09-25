using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Canvas exitMenu;
	public Button levelSelect;
	public Button exitButton;

	public void ExitPressed()
	{
		exitMenu.enabled = true;
		levelSelect.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPressed()
	{
		exitMenu.enabled = false;
		levelSelect.enabled = true;
		exitButton.enabled = true;
	}

	public void LevelSelect()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
		exitMenu = exitMenu.GetComponent<Canvas> ();
		levelSelect = levelSelect.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		exitMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
