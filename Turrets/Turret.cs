using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject ammo;
    public float coolDown;
    public float range;
    public float health;

    private GameObject target;
    private bool lockedEnnemy;
    private float timer;

    void Start() {
        lockedEnnemy = false;
    }

    private void Update() {
        if(health <= 0) {
            GameController.instance.TurretDestroyed();
            Destroy(gameObject);
        }
        if(timer <= coolDown) {
            timer += Time.deltaTime;
            return;
        }
        else {
            timer = 0;
        }

        if (lockedEnnemy == false) {
            CheckForEnnemy();
        }
        else if(lockedEnnemy == true && target == null) {
            return;
        }
        else if (lockedEnnemy == true && Vector3.Distance(transform.position, target.transform.position) < range) {
            Vector3 dir = target.transform.position - transform.position;
            Instantiate(ammo, transform.position, transform.rotation);
            ammo.GetComponent<Ammo>().SetTrajectory(dir.normalized);
            ammo.GetComponent<Ammo>().SetTarget(target);
        }
    }

    void CheckForEnnemy() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, 1 << LayerMask.NameToLayer("Yokai"));
        Debug.Log("Check For ennemy");
        if(hit == true) {
            target = hit.gameObject;
            lockedEnnemy = true;
            Debug.Log("Target ok" + target.name);
        }
        else {
            Debug.Log(hit);
        }
    }

    private void OnDrawGizmos() {
        //Gizmos.DrawSphere(transform.position, range);

    }

    public Transform ReturnTransform() {
        return transform;
    }

    public void Damage(float damage) {
        health -= damage;
    }

    public bool IsDead() {
        if (health == 0) {
            return true;
            
        }
        else {
            return false;
        }
    }

    public float GetHealth() {
        return health;
    }

    public void SetAmmo(GameObject a) {
        ammo = a;
    }


}
