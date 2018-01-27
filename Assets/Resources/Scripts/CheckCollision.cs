using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    private GameObject character;
    public ParticleSystem blood;
    public ParticleSystem smoke;
    public PlayerToss pt;

    private RagdollFalling ragdollFalling;

    private void Start()
    {

        character = GameObject.FindWithTag("Player");
        ragdollFalling = character.GetComponent<RagdollFalling>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            pt.RoadCollision();
        if (collision.gameObject.tag == "Car")
            pt.TopCollision(collision.gameObject);
        if (ragdollFalling.hitTheGround == false)
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Car")
            {
                if (blood != null)
                {
                    blood.Play();
                }
                character.SendMessage("EnableRagdoll");
            }
            if (collision.gameObject.tag == "Ground")
            {
                ragdollFalling.hitTheGround = true;
            }
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
