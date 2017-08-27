using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGenerator : MonoBehaviour {

    public float Probability = 0.1f;

    public GameObject PowerupTemplate;

	// Use this for initialization
	void Start ()
    {
	}

    private float seconds = 0.0f;

	// Update is called once per frame
	void Update ()
    {
        if (PowerupTemplate == null)
            return;

        seconds += Time.deltaTime;
        if (seconds >= 1.0f)
        {
            seconds = 0.0f;

            var diceValue = UnityEngine.Random.Range(1, 100);
            if (diceValue <= Probability * 100)
            {
                var newPowerupObject = Instantiate(PowerupTemplate);
                var newPowerupComponent = newPowerupObject.GetComponent<Powerup>();

                
                diceValue = UnityEngine.Random.Range(1, 4);
                switch (diceValue)
                {
                    case 1:
                        var possibleValues = Enum.GetValues(typeof(TankMovementScript.ProjectileType)) as TankMovementScript.ProjectileType[];
                        diceValue = UnityEngine.Random.Range(0, possibleValues.Length - 1);
                        newPowerupComponent.ProjectileType = possibleValues[diceValue];
                        break;
                    case 2:
                        newPowerupComponent.Health = UnityEngine.Random.Range(25, 100); 
                        break;
                    case 3:
                        newPowerupComponent.Armor = UnityEngine.Random.Range(25, 100);
                        break;
                    case 4:
                        newPowerupComponent.Shield = UnityEngine.Random.Range(25, 100);
                        break;
                }
            }
        }

	}
}
