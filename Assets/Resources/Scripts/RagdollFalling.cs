using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollFalling : MonoBehaviour {

    // Use this for initialization

    public Rigidbody[] rbs;
	void Start () {
        rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
        }
        this.GetComponent<Animator>().enabled = true;
        //DisableRagdoll();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DisableRagdoll()
    {
        //rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }
        this.GetComponent<Animator>().enabled = false;
    }
}
