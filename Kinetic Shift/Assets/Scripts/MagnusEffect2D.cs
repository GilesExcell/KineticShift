using UnityEngine;
using System.Collections;

public class MagnusEffect2D : MonoBehaviour {
	public float coefficient = 0.1f;
	Rigidbody2D body;

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();	
	}
	
	void FixedUpdate () {
		Vector2 magnus = coefficient * body.angularVelocity * body.velocity;
		magnus.Set (-magnus.y, magnus.x);
		Debug.Log (magnus);
		body.AddForce (magnus);
	}
}
