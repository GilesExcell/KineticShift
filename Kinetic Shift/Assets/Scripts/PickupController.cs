using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickupController : MonoBehaviour {

	public int points = 1;
	public GameManager gameManager = null;
	public bool isGoal;

	public AudioClip pickupSound;
	public float soundVolume;

	public Canvas lvlCompScreen;
	public Button levelSelect;


	// Use this for initialization
	void Start () {
		if (gameManager == null) {
			gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		}
		// Load level complete screen items
		lvlCompScreen = lvlCompScreen.GetComponent<Canvas> ();
		levelSelect = levelSelect.GetComponent<Button> ();
		// Hide them
		lvlCompScreen.enabled = false;
		levelSelect.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			gameManager.SendMessage("AddPoints", points);
			AudioSource.PlayClipAtPoint(pickupSound, transform.position, soundVolume);
			Destroy(gameObject);
		}

		if (isGoal){
			//yield WaitForSeconds(1);
			//Application.LoadLevel(1);

			// Display level complete screen
			lvlCompScreen.enabled = true;
			levelSelect.enabled = true;

		}
	}
}
