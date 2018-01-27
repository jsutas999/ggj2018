using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            GameObject.Find("Character_rig").SendMessage("EnableRagdoll");
    }
}
