using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

    public Rigidbody2D Ridgidbody;

    static float maxSpeed = 100.0f;
    public float speed = 10.0f;
    public int lifetime = 500;
	float angle;
	Vector3 dir;

    // Use this for initialization
    void Start()
    {
		angle = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
		dir   = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0.0f);
    }
		

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        speed = Mathf.Min(speed, maxSpeed);
        speed = Mathf.Max(speed, -maxSpeed);
        transform.position += speed * dt * dir;
        lifetime -= 1;
        if (lifetime<1) Destroy(transform.root.gameObject);
    }


}
