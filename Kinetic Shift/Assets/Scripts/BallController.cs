using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	int maxSpeed = 20;
	int accel = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector2.left * Time.deltaTime * accel);
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * Time.deltaTime * accel);
		}
	}
}
