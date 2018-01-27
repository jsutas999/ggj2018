using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    private Rigidbody rb;
    public float moveSpeed = 1;
    public GameObject car;
    public GameObject playerToss;
    public float force, height, side;
    public GameObject cam;
    public GameObject jumpPoint;
    public GameManager gm;

	void Start () {
        rb = GetComponent<Rigidbody>();
        car.transform.parent = transform;
    }

	void Update () {
        float v, h;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // gm.SetSpeed(gm.GetSpeed() + h);
        gm.SetSpeed(15 + v * 5f);

        force = rb.velocity.z * 50;
        force = Mathf.Clamp(force, 200f, 1000f);
        side = rb.velocity.x * 50;
        rb.AddForce(new Vector3(h * moveSpeed * Time.deltaTime, 0, 0));
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

        if (Physics.Raycast(transform.position, -transform.up, 10))
            print("There is something in down of the object!");
    }
}