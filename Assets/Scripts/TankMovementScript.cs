using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour {

	public GameObject projectilePrototype;
	public KeyCode forwardKey;
	public KeyCode backwardKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode fireKey;
	public Vector3 colour = new Vector3 (1.0f, 1.0f, 1.0f);

	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	private GameObject projectile;

	static float epsilonSpeed = 0.01f;
	static float maxSpeed = 1.0f;
	static float maxAccel = 1.0f;
	static float maxDragAccel = 0.5f;
	static float fadeRate = 1.0f;
	static float timeVisibleInit = 1.0f;
	static float fireDelay = 1.0f;
	static float canonLength = 1.0f;
	float accel;
	Vector2 dir;
	Vector2 pos;
	Vector2 force;
	float torque;
	float angle;
	float tFire;
	public float alphaLevel;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
		pos   = transform.position;
		alphaLevel = 1.0f;
		tFire = 0.0f;
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;
		float t = Time.time;

		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));

		Debug.Log ("angle : " + angle + "   " + Mathf.Rad2Deg*angle);

		// Compute torques
		if (Input.GetKey (leftKey)) {
			torque = 1.0f;
		}
		else if (Input.GetKey (rightKey)) {
			torque = -1.0f;
		}
		else {
			torque = 0.0f;
		}

		// Compute forward
		if (Input.GetKey (forwardKey)) {
			accel = maxAccel;
		} else if (Input.GetKey (backwardKey)) {
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

		// Make tank visible if canon is fired
		if (t - tFire > fireDelay && Input.GetKey (fireKey)) {
			alphaLevel = 1.0f;
			tFire = t;
			projectile = Instantiate (projectilePrototype, transform.position, transform.rotation);
			projectile.transform.rotation = transform.rotation;
		}

		// After initial visible time, fade tank
		if (t > timeVisibleInit) {
			alphaLevel -= fadeRate * dt;
		}
		alphaLevel = Mathf.Max (0.0f, alphaLevel);
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);
	
	}

	public void MakeVisible() {
		alphaLevel += 0.5f;
		alphaLevel = Mathf.Max (0.0f, alphaLevel);
	}
}
