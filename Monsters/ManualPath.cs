using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualPath : MonoBehaviour {

    public GameObject lane;
    public List<Transform> targets;
    public float originalSpeed;
    public float speed;

    public int targetNumber = 0;

    private bool speedIncrease, groupSpeedIncrease, gotTarget = false;

    void Start() {
        
	}

    private void Update() {
        if (gotTarget == false) {
            Debug.Log("BUUU");
            Component[] comp = lane.GetComponentsInChildren<TargetTrigger>();
            foreach (TargetTrigger t in comp) {
                if (t != lane.transform) {
                    targets.Add(t.gameObject.transform);
                    gotTarget = true;
                }
                
            }
        }
    }
    void FixedUpdate () {
        if (gotTarget == true) {
            Vector3 dir = (targets[targetNumber].position - transform.position);
            Debug.Log("Dir.z " + dir.z);
            transform.Translate(dir.normalized * speed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            transform.rotation = Quaternion.identity;
        }
        
        
    }

    public void IncrementTargetNumber() {
        targetNumber++;
    }

    public int GetTargetNumber() {
        return targetNumber;
    }

    public void ReduceSpeed(float reduction) {
        if (speed >= 0) {
            speed -= reduction;
        }
        else {
            return;
        }
    }

    public void RestoreSpeed() {
        speed = originalSpeed;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetTargets(List<Transform> targ) {
        targets = new List<Transform>();
        targets = targ;
    }

    public void SetLane(GameObject lan) {
        lane = lan;
    }

    public void SetMultipleLane(GameObject l) {
        lane = l;
        gotTarget = false;
    }

    public Vector3 GetTargetPosition() {
        return targets[targetNumber].position;
    }

    public void SpeedIncrease() {
        speedIncrease = true;
    }

    public void GroupSpeedIncrease() {
        groupSpeedIncrease = true;
    }
}
