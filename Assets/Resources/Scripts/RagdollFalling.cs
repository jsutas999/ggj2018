using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollFalling : MonoBehaviour {

    // Use this for initialization

    public Component[] rbs;
	void Start () {
        DisableRagdoll();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DisableRagdoll()
    {
        rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }
    }
}
