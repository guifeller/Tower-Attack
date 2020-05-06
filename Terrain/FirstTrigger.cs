﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour {

    public GameObject lane;

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.GetComponent<ManualPath>().SetLane(lane);
    }
}
