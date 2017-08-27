using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

    public Rigidbody2D rb;
	public BallisticProps ballistic;
    public int lifetime = 500;
	public float speed = 10.0f;

	private float angle;
	private Vector3 dir;
	private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
		// Set speed of projectile
		ballistic = GetComponent<BallisticProps> ();
		speed = ballistic.speed;

		// Play sound of projectile shooting
		audioSource = GetComponent<AudioSource>();
		AudioClip audioClip = ballistic.audioClip;
		audioSource.PlayOneShot (audioClip);

		// Set mass of projectile
		rb = GetComponent<Rigidbody2D>();
		rb.mass = ballistic.mass;

		// Set direction of projectile from transform angle
		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0.0f);
    }
		

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        transform.position += speed * dt * dir;
        lifetime -= 1;
        if (lifetime<1) Destroy(transform.root.gameObject);
    }


}
