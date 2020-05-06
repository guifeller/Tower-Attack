using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokaiHealth : MonoBehaviour {

    public float originalHealth = 100, health, armor;

    private void Start() {
        health = originalHealth;
    }
    void Update() {
        Debug.Log(health);
        if (health <= 0) {
            Debug.Log("Lose");
            Destroy(gameObject);
            GameController.instance.YokaiDead();
            GameController.instance.CheckObjective();
        }
    }

    public void Damage(float damage) {
        if (armor > 0) {
            armor -= damage;
            if ((armor - damage) < 0) {
                armor = 0;
                float damageH = damage - armor;
                health -= damageH;
            }
        }
        else {
            health -= damage;
        }
        
    }

    public float GetHealth() {
        return health;
    }

    public void RestaureHealth(float h) {
        health += h;
        if (health > originalHealth) {
            health = originalHealth;
        }
    }

    public void AddArmor(float a) {
        armor += a;
    }
}
