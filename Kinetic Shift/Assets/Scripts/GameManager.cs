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
		setScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
	}

	void AddPoints(int points) {
		score += points;
		setScoreText ();
	}

	void RemovePoints(int points) {
		score -= points;
		if (score < 0)
			score = 0;

		setScoreText ();
	}

	void setScoreText(){
		scoreText.text = "Score: " + score.ToString ();
	}
}