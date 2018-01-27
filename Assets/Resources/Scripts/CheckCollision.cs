using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    private GameObject character;
    public ParticleSystem blood;
    public ParticleSystem smoke;

    private void Start()
    {
        character = GameObject.Find("Character_rig");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Car")
        {
            if(blood != null)
            {
                blood.Play();
            }
            character.SendMessage("EnableRagdoll");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag == "Car")
        {
            if (smoke != null)
            {
                smoke.Play();
            }
        }
    }
}
