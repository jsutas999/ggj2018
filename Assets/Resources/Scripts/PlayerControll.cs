using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    private Rigidbody rb;
    public float moveSpeed = 1;
    public float boostSpeed = 1;
    float boost = 1;
    public bool usingCar = true;
    public GameObject car;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void Update () {
        float v=0, h;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
            boost = boostSpeed;
        else
            boost = 1;
        rb.AddRelativeForce(new Vector3(h * moveSpeed, 0, v * moveSpeed * boost));
        //transform.position = car.transform.position;
    }
}
