using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollFalling : MonoBehaviour {

    private Rigidbody[] rbs;

    public bool hitTheGround = false;
    private bool groundIsHit = false;

	void Start () {
        rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
           //rb.isKinematic = true;
        }
        this.GetComponent<Animator>().enabled = true;
        //DisableRagdoll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            EnableRagdoll();
        }
        if (hitTheGround == true && groundIsHit == false)
        {
            groundIsHit = true;
            this.SendMessage("GameOver");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        EnableRagdoll();
    }

    public void EnableRagdoll()
    {
        //rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }
        this.GetComponent<Animator>().enabled = false;
    }
}
