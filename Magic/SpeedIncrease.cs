using UnityEngine;

public class SpeedIncrease : MonoBehaviour {


    public float speed;
    public static SpeedIncrease instance = null;
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
    void Update () {
        Speed();
	}

    void Speed() {
        if (Input.touchCount > 0) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.tag == "Player") {
                hit.transform.gameObject.GetComponent<ManualPath>().SpeedIncrease();
                Destroy(gameObject);
            }
            else {
                Debug.Log("This isn't a Turret");
            }
        }
    }
}
