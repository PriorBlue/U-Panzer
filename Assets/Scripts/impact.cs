using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tank")
        {
            // obst.isShaking = true;
            TankMovementScript tankScript = other.gameObject.GetComponent<TankMovementScript>();
            tankScript.MakeVisible();

        }



        Destroy(transform.root.gameObject);

    }



}
