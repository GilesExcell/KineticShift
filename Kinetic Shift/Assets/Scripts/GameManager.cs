using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score { get; private set; }
	public float currentTime { get; private set; }

	// Use this for initialization
	void Start () {
		score = 0;
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
	}

	void AddPoints(int points) {
		score += points;
	}

	void RemovePoints(int points) {
		score -= points;
		if (score < 0)
			score = 0;
	}
}