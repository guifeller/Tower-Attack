using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour {

    public GameObject[] posCamera;


	public void MoveCamera(int i) {
        transform.position = posCamera[i].transform.position;
    }
}
