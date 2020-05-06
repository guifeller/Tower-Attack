using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour {


    public GameObject oni, wanyuudou;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(oni.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(wanyuudou.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
