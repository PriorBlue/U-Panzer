using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityScript : MonoBehaviour {

	private GameObject tank;
	private Vector3 colour;
	private float alphaLevel;
	private SpriteRenderer spriteRenderer;
	private TankMovementScript tankScript;

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer> ();

		tank = transform.root.gameObject;
		tankScript = tank.GetComponent<TankMovementScript> ();
		colour = new Vector3 (tankScript.colour.x, tankScript.colour.y, tankScript.colour.z);
		alphaLevel = tankScript.alphaLevel;
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);

	}
	
	// Update is called once per frame
	void Update () {

		colour = new Vector3 (tankScript.colour.x, tankScript.colour.y, tankScript.colour.z);
		alphaLevel = tankScript.alphaLevel;
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);

	}
}
