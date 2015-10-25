﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score { get; private set; }
	public float currentTime { get; private set; }
	public GameObject player;
	private CircleController playerController;
	public Text scoreText;
	public Slider energySlider;
	
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

		if (lvlEnd)
		{
			lvlCompScreen.enabled = true;
		}
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