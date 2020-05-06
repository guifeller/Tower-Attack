using UnityEngine;

public class Heal : MonoBehaviour {

    public static Heal instance = null;

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
        HealthRestaure();
    }

    void HealthRestaure() {
        if (Input.touchCount > 0) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.tag == "Player") {
                hit.transform.gameObject.GetComponent<YokaiHealth>().RestaureHealth(GetComponent<YokaiHealth>().GetHealth());
                Destroy(gameObject);
            }
            else {
                Debug.Log("This isn't a Player");
            }
        }
    }
}
