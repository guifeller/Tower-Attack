using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTurretEvent : MonoBehaviour {

    public GameObject eventToGenerate;
    public float healthToTrigger;

    private float healthTurret;
    private bool activated = false;

    // Use this for initialization
    void Start() {
        healthTurret = GetComponent<Turret>().GetHealth();
        eventToGenerate.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (activated == true) {
            return;
        }

        if (healthTurret <= healthToTrigger) {
            eventToGenerate.SetActive(true);
            activated = true;
        }
    }
}