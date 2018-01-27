using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballFall : MonoBehaviour {
    public Rigidbody rb;
	void Start () {
        rb.AddForce(Vector3.up * 10000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
