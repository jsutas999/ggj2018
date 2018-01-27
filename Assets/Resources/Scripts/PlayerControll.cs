using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    private Rigidbody rb;
    public float moveSpeed = 1;
    public float boostSpeed = 1;
    float boost = 1;
    public GameObject car;
    public GameObject playerToss;
    public float force, height, side;
    public GameObject cam;
    public GameObject jumpPoint;
    public SegmentManager gm;

	void Start () {
        rb = GetComponent<Rigidbody>();
        car.transform.parent = transform;
    }

	void Update () {
        float v=0, h;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
            boost = boostSpeed;
        else
            boost = 1;

       // gm.SetSpeed(gm.GetSpeed() + h);

        force = rb.velocity.z * 50;
        force = Mathf.Clamp(force, 200f, 1000f);
        side = rb.velocity.x * 50;

        if (Input.GetKeyDown(KeyCode.Space))
            Crash();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Crash();
    }
    void Crash() {
        GameObject toss;
        toss = Instantiate(playerToss, jumpPoint.transform.position, Quaternion.identity);
        toss.SetActive(true);
        toss.GetComponent<PlayerToss>().force = force;
        toss.GetComponent<PlayerToss>().height = height;
        toss.GetComponent<PlayerToss>().side = side;
        car.transform.parent = null;
        cam.GetComponent<CameraFollow>().target = toss;
        gameObject.SetActive(false);
    }
}