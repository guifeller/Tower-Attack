using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public float speed = 0.1F;
    public Transform minX, maxX, minY, maxY;

    private float mX, pX, mY, pY;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is cal

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
            if(transform.position.x > pX) {
                transform.position = new Vector3(pX, transform.position.y, transform.position.z);
            }
            if (transform.position.x < mX) {
                transform.position = new Vector3(mX, transform.position.y, transform.position.z);
            }
            if (transform.position.y > pY) {
                transform.position = new Vector3(transform.position.x, pY, transform.position.z);
            }
            if (transform.position.y < mY) {
                transform.position = new Vector3(transform.position.x, mY, transform.position.z);
            }
        }
    }
}
