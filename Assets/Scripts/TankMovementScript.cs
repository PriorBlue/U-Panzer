using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour {

	static float epsilonSpeed = 0.01f;
	static float maxSpeed = 1.0f;
	static float maxAccel = 1.0f;
	static float maxDragAccel = 0.5f;
	float accel = 0.0f;
	float speed = 0.0f;
	Vector3 dir = new Vector3(1.0f, 0.0f, 0.0f);
	Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float dt = Time.fixedDeltaTime;

		if (speed > epsilonSpeed) {
			accel = -maxDragAccel;
		} else if (speed < -epsilonSpeed) {
			accel = maxDragAccel;
		} else {
			accel = 0.0f;
		}

		if (Input.GetKey (KeyCode.W)) {
			accel += maxAccel;
		} else if (Input.GetKey (KeyCode.S)) {
			accel -= maxAccel;
		}

		speed += accel * dt;
		speed = Mathf.Min (speed, maxSpeed);
		speed = Mathf.Max (speed, -maxSpeed);
		transform.position += speed * dt * dir;
	
	}
}
