using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColli : MonoBehaviour {

	public Obstacles obst;


	// Collision of Trees
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Tank")
		{
			obst.isShaking = true;

		}	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Tank")
		{
			obst.isShaking = false;
		}	
	}

	// Collision of Stones
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Tank")
		{

			obst.isShaking = true;

		}	
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Tank")
		{
			obst.isShaking = false;

		}	
	}
}
