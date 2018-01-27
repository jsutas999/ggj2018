using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollFalling : MonoBehaviour {

    private Rigidbody[] rbs;
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
