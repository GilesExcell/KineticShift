using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	public int points = 1;
	public GameManager gameManager = null;
	public bool isGoal;

	public AudioClip pickupSound;
	public float soundVolume;

	public GameObject pickUpParticle;

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
			gameManager.SendMessage("AddPoints", points);
			AudioSource.PlayClipAtPoint(pickupSound, transform.position, soundVolume);
			GameObject pickUp = (GameObject)Instantiate(pickUpParticle, transform.position, transform.rotation);

			Destroy(gameObject);
		}

		if (isGoal){
			//yield WaitForSeconds(1);
			Application.LoadLevel(1);
		}
	}
}
