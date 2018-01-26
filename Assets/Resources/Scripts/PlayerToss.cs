using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour {
    public float force, height;
    private Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, height, force));
    }
}
