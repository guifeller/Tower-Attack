using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public GameObject target;
    public Vector3 direction;
    public float speed;
    public float damage;
    public float acceleration;
    public float distanceToKill;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float distThisFrame = speed * Time.deltaTime;
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        if(target.GetComponent<YokaiHealth>() != null) {
            if (target.GetComponent<YokaiHealth>().health <= 0) {
                Destroy(gameObject);
                return;
            }
            if (Vector3.Distance(transform.position, target.transform.position) <= distanceToKill) {
                target.GetComponent<YokaiHealth>().Damage(damage);
                Destroy(gameObject);
            }

            else {
                Vector3 vDirection = target.transform.position - transform.position;
                transform.Translate(vDirection.normalized * distThisFrame);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * acceleration);
            }
        }

        if(target.GetComponent<Turret>() != null) {
            if(target.GetComponent<Turret>().IsDead() == true) {
                Destroy(gameObject);
                return;
            }
            if (Vector3.Distance(transform.position, target.transform.position) <= distanceToKill) {
                target.GetComponent<Turret>().Damage(damage);
                Destroy(gameObject);
            }

            else {
                Vector3 vDirection = target.transform.position - transform.position;
                transform.Translate(vDirection.normalized * distThisFrame);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * acceleration);
            }
        }
	}

    public void SetTrajectory(Vector3 dir) {
        direction = dir;
    }

    public void SetTarget(GameObject targ) {
        target = targ;
    }
}
