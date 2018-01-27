using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    private Rigidbody rb;
    public float moveSpeed = 1;
    public GameObject car;
    public GameObject playerToss;
    public float height, side;
    public GameObject cam;
    public GameObject jumpPoint;
    public GameManager gm;
    public PlayerToss pToss;
    float jump;


	void Start () {
        rb = GetComponent<Rigidbody>();
        car.transform.parent = transform;
    }

	void Update () {
        float v, h;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // gm.SetSpeed(gm.GetSpeed() + h);
        gm.SetSpeedScenery(20 + v * 5f);
        gm.SetSpeedCars(10 + v * 5f);

        jump = height + v * 100;
        side = rb.velocity.x * 50;
        transform.position += new Vector3(h * Time.deltaTime * moveSpeed, 0, 0);
        //rb.AddForce(new Vector3(h * moveSpeed * Time.deltaTime * 100, 0, 0));
        if (Input.GetKeyDown(KeyCode.Space))
            Crash();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
            Crash();
        //Debug.Log("Hit " + collision.collider);
    }
    void Crash() {
        GameObject toss;
        toss = Instantiate(playerToss, jumpPoint.transform.position, Quaternion.identity);
        toss.SetActive(true);
        pToss = toss.GetComponent<PlayerToss>();
        pToss.height = jump;
        pToss.side = side;
        gm.AddCarToSegment(car);

        cam.GetComponent<CameraFollow>().target = toss;
        gameObject.SetActive(false);
    }
}