using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    public ParticleSystem blood;
    public PlayerToss pt;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Car" || collision.gameObject.tag == "Obstacle")
        {
            if (blood != null)
                blood.Play();
        }

        if (collision.gameObject.tag == "Ground") {
            pt.RoadCollision();
        }
    }

    private void OnTriggerEnter(Collider other) { //Top Trigger
        pt.TopTrigger(other.gameObject);
    }
}
