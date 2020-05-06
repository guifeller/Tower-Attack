using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTurretChangeWeapon : MonoBehaviour {

    public GameObject ammo;
    public float healthToTrigger;

    private float healthTurret;
    private bool activated = false;

	// Use this for initialization
	void Start () {
        healthTurret = GetComponent<Turret>().GetHealth();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(activated == true) {
            return;
        }

		if(healthTurret <= healthToTrigger) {
            GetComponent<Turret>().SetAmmo(ammo);
            activated = true;
        }
	}
}
