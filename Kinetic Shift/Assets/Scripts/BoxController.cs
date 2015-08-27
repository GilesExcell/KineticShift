using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {
	
	int accel = 10;
	int jumpHeight = 400;
	int kineticEnergy = 50;
	int keBoost = 20;
	bool canJump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Lock z axis
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

		//Lock Rotation
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			if (Input.GetKey(KeyCode.LeftShift && kineticEnergy > 1)) {
				transform.Translate(Vector2.left * Time.deltaTime * keBoost);
				kineticEnergy -= 1;
			}
			else
			{
				transform.Translate(Vector2.left * Time.deltaTime * accel);
				kineticEnergy += 3;
			}
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {
				transform.Translate(Vector2.right * Time.deltaTime * keBoost);
				kineticEnergy -= 1;
			}
			else
			{
				transform.Translate(Vector2.right * Time.deltaTime * accel);
				kineticEnergy += 3;
			}
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			//transform.Translate(Vector2.up * Time.deltaTime, Space.World);

			Jump();
		}


	}

	void Jump () {
		if (Input.GetKey(KeyCode.LeftShift)){
			GetComponent<Rigidbody>().AddForce(Vector2.up * (jumpHeight * 2));
		}
		else
		{
			GetComponent<Rigidbody>().AddForce(Vector2.up * jumpHeight);
		}
	}
	
}
