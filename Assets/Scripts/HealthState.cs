using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState : MonoBehaviour {

    public Hitable Hitable;
    [Range(1, 200)]
    public float MaxHealth = 100;


    private UnityEngine.UI.Slider slider;

    // Use this for initialization
    void Start ()
    {
        slider = GetComponentInParent<UnityEngine.UI.Slider>();		
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
