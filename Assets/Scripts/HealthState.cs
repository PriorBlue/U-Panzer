using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthState : MonoBehaviour {

    public Hitable Hitable;
    [Range(1, 200)]
    public float MaxHealth = 100;


    private Slider slider;

    // Use this for initialization
    void Start ()
    {
        slider = GetComponentInParent<Slider>();		
	}



    // Update is called once per frame
    void FixedUpdate()
    {
        if (slider != null && Hitable != null)
        {
            slider.value = Hitable.health / MaxHealth;
        }

    }
}
