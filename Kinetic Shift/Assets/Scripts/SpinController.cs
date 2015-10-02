using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class SpinController : MonoBehaviour {
	public float spinSpeed;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		body.angularVelocity = spinSpeed;
	}
}
