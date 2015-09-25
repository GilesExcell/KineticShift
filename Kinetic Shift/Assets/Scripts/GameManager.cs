using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score { get; private set; }
	public float currentTime { get; private set; }
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		currentTime = 0;

		SetScoreText();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
	}

	// Add points to the player's score
	void AddPoints(int points) {
		score += points;
		SetScoreText();

	}

	// Remove points from the player's score
	void RemovePoints(int points) {
		score -= points;
		if (score < 0)
			score = 0;

		SetScoreText ();
	}

	// Set the player's score as the text to display
	void SetScoreText(){
		scoreText.text = "Score: " + score.ToString ();
	}
}