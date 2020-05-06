using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIncrease : MonoBehaviour {


    public float armor;
    public static ArmorIncrease instance = null;
    // Use this for initialization
    private void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        Armor(armor);
    }

    void Armor(float aI) {
        if (Input.touchCount > 0) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.tag == "Player") {
                hit.transform.gameObject.GetComponent<YokaiHealth>().AddArmor(aI);
                Destroy(gameObject);
            }
            else {
                Debug.Log("This isn't a Turret");
            }
        }
    }
}
