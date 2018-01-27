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

        height = 150 + v * 50;
        side = rb.velocity.x * 50;
        rb.AddForce(new Vector3(h * moveSpeed * Time.deltaTime * 100, 0, 0));
        if (Input.GetKeyDown(KeyCode.Space))
            Crash();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Crash();
    }
    void Crash() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.175f, 0), -Vector3.up, out hit))
            Debug.Log(hit);
        GameObject toss;
        toss = Instantiate(playerToss, jumpPoint.transform.position, Quaternion.identity);
        toss.SetActive(true);
        //rb.AddTorque(new Vector3(5, 0, Random.Range(-1, 1)));
        pToss = toss.GetComponent<PlayerToss>();
        pToss.height = height;
        pToss.side = side;
        car.transform.parent = hit.transform;
        cam.GetComponent<CameraFollow>().target = toss;
        gameObject.SetActive(false);

        
    }
}