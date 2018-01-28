using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    public ParticleSystem blood;
    public ParticleSystem smoke;
    public PlayerToss pt;

    void OnCollisionEnter(Collision collision) {
        if (blood != null)
            blood.Play();
        if (collision.gameObject.tag == "Ground") {
            pt.RoadCollision();
            return;
        }
    }

    private void OnTriggerEnter(Collider other) { //Top Trigger
        if(smoke != null)
            smoke.Play();
        pt.TopTrigger(other.gameObject);
    }
}
