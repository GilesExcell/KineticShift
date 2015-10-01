using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target = null;
	public float maxDistance;
	public Camera gameCamera;

	public float minSize = 10;
	public float maxSize = 20;
	float wantedSize = 10;

	// Use this for initialization
	void Start () {
		if (target == null) {
			target = GameObject.Find("Player").transform;
		}
		if (gameCamera == null) {
			gameCamera = GetComponentInChildren<Camera>();
		}
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		float distance = (transform.position - target.position).magnitude;

		wantedSize = Mathf.Lerp (minSize, maxSize, distance / maxDistance);
		gameCamera.orthographicSize = Mathf.Lerp (gameCamera.orthographicSize, wantedSize, Time.deltaTime);

		transform.position = Vector2.Lerp (transform.position, target.position, distance * Time.deltaTime);
		if (distance > maxDistance) {
			Vector3 direction = (transform.position - target.position).normalized;
			transform.position = target.position + direction * maxDistance;
		}
	}
}
