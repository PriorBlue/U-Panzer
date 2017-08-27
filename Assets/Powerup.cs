using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public SpriteRenderer Sprite;

    public TankMovementScript.ProjectileType ProjectileType = TankMovementScript.ProjectileType.Std;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed)
        {
            return;
        }

        var tankMovementScript = other.gameObject.GetComponent<TankMovementScript>();
        if (tankMovementScript == null)
            return;

        tankMovementScript.projectileType = ProjectileType;


        fadeOutTime_sec_current = FadeOutTime_sec;
        isDestroyed = true;
    }


    private bool isDestroyed = false;
    [Range(0, 10)]
    public float FadeOutTime_sec = 1.0f;
    private float fadeOutTime_sec_current = 0.0f;

    private void Update()
    {
        if (Sprite == null) return;

        if (isDestroyed)
        {
            var alpha = fadeOutTime_sec_current / FadeOutTime_sec;

            Sprite.color = new Color(1, 1, 1, alpha);

            fadeOutTime_sec_current -= Time.deltaTime;

            if (fadeOutTime_sec_current <= 0)
                Destroy(gameObject);
        }
    }

    
}
