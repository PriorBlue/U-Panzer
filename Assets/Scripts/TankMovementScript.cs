using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour {

	public Rigidbody2D rb;
	static float epsilonSpeed = 0.01f;
	static float maxSpeed = 1.0f;
	static float maxAccel = 1.0f;
	static float maxDragAccel = 0.5f;
	float accel;
	Vector2 dir;
	Vector2 pos;
	Vector2 force;
	float torque;
	float angle;

	// Use this for initialization
	void Start () {
		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
		pos   = transform.position;
		rb    = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;

		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));

		Debug.Log ("angle : " + angle + "   " + Mathf.Rad2Deg*angle);

		// Compute torques
		if (Input.GetKey (KeyCode.A)) {
			torque = 1.0f;
		}
		else if (Input.GetKey (KeyCode.D)) {
			torque = -1.0f;
		}
		else {
			torque = 0.0f;
		}

		// Compute forward
		if (Input.GetKey (KeyCode.W)) {
			accel = maxAccel;
		} else if (Input.GetKey (KeyCode.S)) {
			accel = -maxAccel;
		} else {
			accel = 0.0f;
		}

		// Compute force to drive tank forward
		force = accel*dir;

		// Only allow a torque to rotate the tank when the tank is moving
		torque = accel * torque;

		// Finally add force/torque to Rigid body
		rb.AddForce(force);
		rb.AddTorque(torque);
	
	}
}
