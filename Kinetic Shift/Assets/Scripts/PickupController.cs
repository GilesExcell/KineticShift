using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	public int points = 1;
    public bool isWin;
	public GameManager gameManager = null;

	// Use this for initialization
	void Start () {
		if (gameManager == null) {
			gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
            if (isWin)
            {
                Debug.Log("You win!");
                Destroy(gameObject);
            }
            else
            {
                gameManager.SendMessage("AddPoints", points);
                Destroy(gameObject);
            }
		}
	}
}
