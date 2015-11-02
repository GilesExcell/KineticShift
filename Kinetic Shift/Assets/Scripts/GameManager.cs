using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score { get; private set; }
	public float currentTime { get; private set; }
	public Text timerText;
	public GameObject player;
	private CircleController playerController;
	public Text scoreText;
	public Slider energySlider;
	public Text Results;
	public Canvas lvlCompScreen;

	public bool lvlEnd; // Player completed level

	// Use this for initialization
	void Start () {
		score = 0;
		currentTime = 0;
		if (player == null) {
			player = GameObject.Find("Player");
		}
		playerController = player.GetComponent<CircleController>();

		lvlCompScreen.enabled = false;
		lvlEnd = false;

		UpdateKESlider();
		UpdateScoreText();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		UpdateKESlider();

		// Has the player finished the level?
		if (lvlEnd)
		{
			// Set score and time results
			Results.text = ((int)currentTime).ToString () + " Seconds" +" | " + score.ToString () + " Pts";

			// Display screen with points and lvl select button
			lvlCompScreen.enabled = true;
			lvlEnd = false; // Prevent score and time from updating
		}

		timerText.text = "Time: " + ((int)currentTime).ToString () + "s";
	}

	// Add points to the player's score
	void AddPoints(int points) {
		score += points;
		UpdateScoreText();

	}

	// Remove points from the player's score
	void RemovePoints(int points) {
		score -= points;
		if (score < 0)
			score = 0;

		UpdateScoreText ();
	}

	// Update the value of the kinetic energy slider
	void UpdateKESlider() {
		energySlider.value = playerController.storedEnergy;
	}

	// Set the player's score as the text to display
	void UpdateScoreText(){
		scoreText.text = "Score: " + score.ToString ();
	}
}