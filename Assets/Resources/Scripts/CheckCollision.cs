using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    private GameObject character;
    private GameObject particleObject;
    public ParticleSystem blood;

    private void Start()
    {
        particleObject = this.gameObject.transform.GetChild(0).gameObject;
        blood = particleObject.GetComponent<ParticleSystem>();
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
}
