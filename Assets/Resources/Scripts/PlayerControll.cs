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
    public GameObject playerToss;
    public float force, height;
    public GameObject cam;
    public GameObject jumpPoint;
    bool crash = false;

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
        if (usingCar)
        {
            //car.GetComponent<BoxCollider>().enabled = false;
            car.transform.parent = transform;
            car.transform.position = transform.position;
        }
        force = rb.velocity.z * 50;
        force = Mathf.Clamp(force, 200f, 1000f);
        if (Input.GetKeyDown(KeyCode.Space) && !crash)
            Crash();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!crash) Crash();
    }
    void Crash() {
        crash = true;
        GameObject toss;
        toss = Instantiate(playerToss, jumpPoint.transform.position, Quaternion.identity);
        toss.SetActive(true);
        toss.GetComponent<PlayerToss>().force = force;
        toss.GetComponent<PlayerToss>().height = height;
        car.transform.parent = null;
        cam.GetComponent<CameraFollow>().target = toss;
        gameObject.SetActive(false);
    }
}