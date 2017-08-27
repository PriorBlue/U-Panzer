using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TankMovementScript : MonoBehaviour {

	private enum TankState {
		alive, 
		dead
	};

	public enum ProjectileType
	{
		Std,
		AP,
        HE,
        Hvy
	};

    [System.Serializable]
    public struct Projectile
    {
        public ProjectileType Type;
        public GameObject Prefab;
    }

    public ProjectileType CurrentProjectile = ProjectileType.Std;
    public List<Projectile> ProjectilePrototypes;

	static float canonLength = 1.8f;
	static float fadeRate = 1.0f;
	static float healthInit = 1.0f;
    public float maxAccel = 1.0f;
    public float maxTorque = 1.0f;

    static float timeVisibleInit = 1.0f;

	public AudioClip tankDestroyedAudio;
	public AudioClip tankHitAudio;
	public KeyCode forwardKey;
	public KeyCode backwardKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode fireKey;
	public Color colour = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	public float alphaLevel;

	private float angle;
	private float tFire;
	private float fireDelay;
	private TankState state;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource          = GetComponent<AudioSource> ();
		rb                   = GetComponent<Rigidbody2D> ();
		spriteRenderer       = GetComponent<SpriteRenderer> ();
		CurrentProjectile    = ProjectileType.Std;
		state                = TankState.alive;
		alphaLevel           = 1.0f;
		tFire                = 0.0f;
		angle                = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		spriteRenderer.color = new Color (colour.r, colour.g, colour.b, alphaLevel);
		SetFireDelay ();
	}


	// Update is called once per frame
	void FixedUpdate () {

	    // If tank is dead, then set to dead colour
		if (state == TankState.dead) {
			colour = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			spriteRenderer.color = Color.gray;
			return;
		}
			
		float dt = Time.fixedDeltaTime;
		float t = Time.time;
		float torque = 0.0f;
		float accel = 0.0f;

		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		Vector3 dir = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0.0f);

		// Compute torques
		if (Input.GetKey (leftKey)) {
			torque = maxTorque;
		}
		else if (Input.GetKey (rightKey)) {
			torque = -maxTorque;
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
		Vector3 force = accel*dir;

		// Only allow a torque to rotate the tank when the tank is moving
		torque = accel * torque;

		// Finally add force/torque to Rigid body
		rb.AddForce(force);
		rb.AddTorque(torque);

		// Make tank visible if canon is fired
		if (t - tFire > fireDelay && Input.GetKey (fireKey)) {
			alphaLevel = 1.0f;
			tFire = t;

			// Create projectile instance
			Instantiate (ProjectilePrototypes.FirstOrDefault(it => it.Type == CurrentProjectile).Prefab,
				         transform.position + canonLength*dir, 
				         transform.rotation);
		}

		// After initial visible time, fade tank
		if (t > timeVisibleInit) {
			alphaLevel -= fadeRate * dt;
		}
		alphaLevel = Mathf.Max (0.0f, alphaLevel);
		spriteRenderer.color = new Color (colour.r, colour.g, colour.b, alphaLevel);

        Hitable HitableComp = gameObject.GetComponent<Hitable>();
        Color HC = HitableComp.ShieldHalo.color;
        if (HitableComp.shield < 100) { HC.a = HitableComp.shield; }
        if (HitableComp.shield >= 100) { HC.a = 100; }
        if (HitableComp.shield < 1) { HC.a = 0; }
        if (HC.a > alphaLevel) { HC.a = alphaLevel; }
       
        HitableComp.ShieldHalo.color = HC;

        if (alphaLevel < 1) { HitableComp.enabled = false; } else HitableComp.enabled = true;

    }


	public void HitByProjectile() {
		MakeVisible ();
		audioSource.PlayOneShot (tankHitAudio);
	}


	public void MakeVisible() {
		alphaLevel += 0.5f;
		alphaLevel = Mathf.Max (0.0f, alphaLevel);
	}


    public void Destruction()
    {
		if (state == TankState.alive) {
			state = TankState.dead;
			audioSource.PlayOneShot (tankDestroyedAudio);
		}
    }


	public void SetFireDelay()
	{
		GameObject projectile = ProjectilePrototypes.FirstOrDefault (it => it.Type == CurrentProjectile).Prefab;
		BallisticProps ballistic = projectile.GetComponent<BallisticProps> ();
		fireDelay = ballistic.fireDelay;
	}
}
