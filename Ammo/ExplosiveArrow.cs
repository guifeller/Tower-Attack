using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveArrow : MonoBehaviour {

    public GameObject target;
    public Vector3 direction;
    public float speed;
    public float damage;
    public float acceleration;
    public float distanceToKill;
    public float aoe;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distThisFrame = speed * Time.deltaTime;
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        if (target.GetComponent<YokaiHealth>().health <= 0) {
            Destroy(gameObject);
            return;
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= distanceToKill) {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, aoe, 1 << LayerMask.NameToLayer("Player"));
            for(int i = 0; i < targets.Length; i++) {
                targets[i].GetComponent<YokaiHealth>().Damage(damage);
            }
            Destroy(gameObject);
        }

        else {
            
            Vector3 vDirection = target.transform.position - transform.position;
            transform.Translate(vDirection.normalized * distThisFrame);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * acceleration);
        }
    }

    public void SetTrajectory(Vector3 dir) {
        direction = dir;
    }

    public void SetTarget(GameObject targ) {
        target = targ;
    }
}
