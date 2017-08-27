using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public SpriteRenderer Sprite;
    public ParticleSystem Particle;

    [Range(0, 10)]
    public float FadeOutTime_sec = 1.0f;

    public TankMovementScript.ProjectileType ProjectileType = TankMovementScript.ProjectileType.Std;

    public float Health = 0;
    public float Armor = 0;
    public float Shield = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit)
        {
            return;
        }

        var powerupActivated = false;

        var tankMovementScript = other.gameObject.GetComponent<TankMovementScript>();
        if (tankMovementScript != null)
        {
            powerupActivated = true;
            tankMovementScript.CurrentProjectile = ProjectileType;
			tankMovementScript.SetFireDelay ();
        }

        var hitable = other.gameObject.GetComponent<Hitable>();
        if (hitable != null)
        {
            powerupActivated = true;
            hitable.health += Health;
            hitable.armor += Armor;
            hitable.shield += Shield;
        }

        if (powerupActivated)
        {
            fadeOutTime_sec_current = FadeOutTime_sec;
            isHit = true;
            Particle.Stop();
        }
    }


    private bool isHit = false;
    private float fadeOutTime_sec_current = 0.0f;

    private void Update()
    {
        if (Sprite == null) return;

        if (isHit)
        {
            var alpha = fadeOutTime_sec_current / FadeOutTime_sec;

            Sprite.color = new Color(1, 1, 1, alpha);

            fadeOutTime_sec_current -= Time.deltaTime;

            if (fadeOutTime_sec_current <= 0)
                Destroy(gameObject);
        }
    }

    
}
