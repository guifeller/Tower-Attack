using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoiceTrigger : MonoBehaviour {

    public GameObject[] lanes;

    private int choice;

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.GetComponent<ManualPath>().SetMultipleLane(lanes[choice]);
    }

    public void SelectLane(int i) {
        choice = i;
    }
}
