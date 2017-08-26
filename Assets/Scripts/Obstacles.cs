using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	public Transform trans;
	public float shakeTime; //
	public float speed = 1.0f; //how fast it shakes
	public float amount = 1.0f; //how much it shakes
	float timer;
	bool Up;
	bool Right;

	public bool isShaking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Shake2();
		if(isShaking) Shake();
	}


	void Shake()
	{
		trans.localPosition = new Vector3(Mathf.Sin(Time.time *speed)*amount, Mathf.Cos((Time.time+0.3f) * speed)*amount, 0f);
	}

	public void Shake2()
	{
		//if(timer <= shakeTime){
			
			//Up = Random.Range (-1f, 1f) < 0 ? true : false;
			//Right = Random.Range (-1f, 1f) < 0 ? true : false;


			if(Up){
				trans.position += new Vector3(0,0.05f,0);
				Up = false;
			}
			else
			{
				trans.position -= new Vector3(0,0.05f,0); //translate(0,-0.1f,0);
				Up = true;
			}
			if(Right){
				trans.position += new Vector3(0.05f,0,0);
				Right = false;
			}
			else
			{
				trans.position -= new Vector3(0.05f,0,0); //translate(0,-0.1f,0);
				Right = true;
			}
		//	timer += Time.deltaTime; // Time.time; // time.deltaTime;
		//}
	}
}
