using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProps : MonoBehaviour {


    public float damage = 25.0f;
    [Range(0.01f, 10)] public float healthmod = 1.0f;
    [Range(0.01f, 10)] public float armormod = 0.2f;
    [Range(0.01f, 10)] public float shieldmod = 0.1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
