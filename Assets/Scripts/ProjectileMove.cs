using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

    public Rigidbody2D Ridgidbody;


    static float epsilonSpeed = 0.01f;
    static float maxSpeed = 100.0f;
    static float maxAccel = 30.0f;
    static float maxDragAccel = 0.03f;
    float accel = 0.0f;
    public float speed = 5.0f;
    Vector3 dir = new Vector3(1.0f, 0.0f, 0.0f);
    Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float dt = Time.fixedDeltaTime;

        if (speed > epsilonSpeed)
        {
            accel = -maxDragAccel;
        }
        else if (speed < -epsilonSpeed)
        {
            accel = maxDragAccel;
        }
        else
        {
            accel = 0.0f;
        }
       

        speed += accel * dt;
        speed = Mathf.Min(speed, maxSpeed);
        speed = Mathf.Max(speed, -maxSpeed);
        transform.position += speed * dt * dir;

      

    }


}
