using UnityEngine;
using System.Collections;

public class EnergyDrain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<CircleController>().storedEnergy = 0;
		}
	}
}
