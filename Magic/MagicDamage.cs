using UnityEngine;

public class MagicDamage : MonoBehaviour {


    public float damage;
    public static MagicDamage instance = null;

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
        FireBall(damage);
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }

    void FireBall(float d) {
        if(Input.touchCount > 0) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.tag == "Turret") {
                hit.transform.gameObject.GetComponent<Turret>().Damage(d);
                Destroy(gameObject);
            }
            else {
                Debug.Log("This isn't a Turret");
            }
        }
        
        
    }
}
