using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact : MonoBehaviour {

    public BallisticProps Ballisitcs;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        TankMovementScript tankScript = other.gameObject.GetComponent<TankMovementScript>();

        if (other.gameObject.tag == "Tank")
        {
            tankScript.HitByProjectile();
        }
        

        // resolve hit
        Hitable HitableComp  = other.gameObject.GetComponent<Hitable>();
        float damageRemain = Ballisitcs.damage;

        if (HitableComp != null)
        {
            if (HitableComp.shield > damageRemain * Ballisitcs.shieldmod)
            { HitableComp.shield -= damageRemain * Ballisitcs.shieldmod; }
            else
            {
                float absorb = HitableComp.shield / Ballisitcs.shieldmod;
                HitableComp.shield = 0.0f;
                damageRemain -= absorb;
            }


            if (HitableComp.armor > damageRemain * Ballisitcs.armormod)
            { HitableComp.armor -= damageRemain * Ballisitcs.armormod; }
            else
            {
                float absorb = HitableComp.armor / Ballisitcs.armormod;
                HitableComp.armor = 0.0f;
                damageRemain -= absorb;
            }

            if (HitableComp.health > damageRemain * Ballisitcs.healthmod)
            {
                HitableComp.health -= damageRemain * Ballisitcs.healthmod;
            }
            else
            {
                if (other.gameObject.tag == "Tank")
                {
                    // Destroy tanks
                    tankScript.Destruction();
                }
                else Destroy(HitableComp.ObjToRemove);
            }
            
            // Destroy Projectile
            Destroy(transform.root.gameObject);

        }


    }



}
