using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackMelee : MonoBehaviour {

    public GameObject ammo;
    //public GameObject turrets;
    public float range, damage;
    public float coolDown;
    public bool isDistance;

    //private List<Transform> targ;
    //private int i = 0;
    private float timer;
    private GameObject targ;
    private bool t;

    private void Awake() {
        //Méthode ancienne, à utiliser si nécessaire
        //Component[] comp = turrets.GetComponentsInChildren<Turret>();

        //foreach(Turret i in comp) {
        //    targ.Add(i.transform);
        //}
        //targ = targ.OrderBy(target => Vector3.Distance(transform.position, target.position)).ToList();
    }

    private void Start() {
        StartCoroutine("CheckForEnnemy");
    }

    private void Update() {
        //float dist = Vector3.Distance(transform.position, targ[i].position);
        if(t == true ) {
            if(targ == null) {
                t = false;
                GetComponent<ManualPath>().RestoreSpeed();
            }
            Debug.Log("t == true");
            float dist = Vector3.Distance(transform.position, targ.transform.position);
            if (dist <= range) {
                GetComponent<ManualPath>().ReduceSpeed(GetComponent<ManualPath>().GetSpeed());
                if (timer <= coolDown) {
                    timer += Time.deltaTime;
                    return;
                }
                else {
                    timer = 0;
                }
                Vector3 dir = targ.transform.position - transform.position;
                Instantiate(ammo, transform.position, transform.rotation);
                ammo.GetComponent<Ammo>().SetTrajectory(dir.normalized);
                ammo.GetComponent<Ammo>().SetTarget(targ);
                GetComponent<AnimationController>().AttackAnimation();
                if (targ.GetComponent<Turret>().IsDead() == true) {
                    t = false;
                    GetComponent<ManualPath>().RestoreSpeed();
                }
            }
        

        }
    }

    public IEnumerator CheckForEnnemy() {
        while(true) {
            Debug.Log("Coroutine Started");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, range, 1 << LayerMask.NameToLayer("Turret"));
            Debug.DrawRay(transform.position, Vector2.up);
            if (hit.collider != null) {
                Debug.Log("GotTarget");
                targ = hit.collider.gameObject;
                t = true;
            }
            yield return new WaitForSeconds(0.2f);
        }   
    }
}
