using UnityEngine;

public class TargetTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player") {

            if (collision.GetComponent<ManualPath>().GetTargetNumber() >= collision.GetComponent<ManualPath>().targets.Count - 1) {
                return;
            }
            else {
                collision.GetComponent<ManualPath>().IncrementTargetNumber();
            }
            collision.GetComponent<AnimationController>().ChooseAnimation();
        }
    }
}
