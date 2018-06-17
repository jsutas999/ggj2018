using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    public ParticleSystem blood;
    public PlayerToss pt;
    bool gameover = false;

    void OnCollisionEnter(Collision collision) {
        Hit(false, collision.gameObject);
    }
    private void OnTriggerEnter(Collider other) { //Top Trigger
        Hit(true, other.gameObject);
    }
    private void Hit(bool trigger, GameObject obj) {
        if (trigger && !gameover)
            pt.Collision(trigger, obj);
        else
            if (obj.tag == "Ground" || obj.tag == "Car" || obj.tag == "Obstacle") {
                if (blood != null)
                    blood.Play();
                if (obj.tag == "Ground") {
                    pt.Collision(false, obj);
                    gameover = true;
                }
            }
    }
}
