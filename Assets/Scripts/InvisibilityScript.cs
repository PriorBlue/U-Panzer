using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityScript : MonoBehaviour {

    public TankMovementScript tankScript;
    public SpriteRenderer spriteRenderer;

    private GameObject tank;
	private Vector3 colour;
	private float alphaLevel;

	// Use this for initialization
	void Start () {

		tank = transform.root.gameObject;
		colour = new Vector3 (tankScript.colour.r, tankScript.colour.g, tankScript.colour.b);
		alphaLevel = tankScript.alphaLevel;
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);

	}
	
	// Update is called once per frame
	void Update () {

		colour = new Vector3 (tankScript.colour.r, tankScript.colour.g, tankScript.colour.b);
		alphaLevel = tankScript.alphaLevel;
		spriteRenderer.color = new Color (colour.x, colour.y, colour.z, alphaLevel);

	}
}
