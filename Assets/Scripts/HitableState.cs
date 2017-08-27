using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitableState : MonoBehaviour {

    public Hitable Hitable;
    [Range(1, 200)]
    public float MaxValue = 100;

    public Properties Property = HitableState.Properties.Health;

    public enum Properties
    {
        Health,
        Armor,
        Shield
    }

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
            var value = 0.0f;
            switch (Property)
            {
                case Properties.Armor:
                    value = Hitable.armor;
                    break;
                case Properties.Shield:
                    value = Hitable.shield;
                    break;
                case Properties.Health:
                default:
                    value = Hitable.health;
                    break;
            }

            slider.value = value / MaxValue;
        }

    }
}
