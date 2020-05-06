using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            
            GameController.instance.UpdateScore(collision.gameObject);
            //Remove one yokai from the game, even if not dead.
            GameController.instance.YokaiDead();
            GameController.instance.UpdateArrivedYokai();
            GameController.instance.CheckObjective();
            Destroy(collision.gameObject);
        }
    }
}
