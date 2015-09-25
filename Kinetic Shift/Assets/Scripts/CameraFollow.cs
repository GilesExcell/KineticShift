using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target = null;
	public float highSpeed = 10;
	public float lowSpeed = 1;
	public float maxDistance;

	// Use this for initialization
	void Start () {
		if (target == null) {
			target = GameObject.Find("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float distance = (transform.position - target.position).magnitude;


		//transform.position = Vector2.Lerp (transform.position, target.position, distance * Time.deltaTime);
		transform.position = target.position;
	}
}
