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

    private FuelBar fb;
    


	void Start () {
        rb = GetComponent<Rigidbody>();
        car.transform.parent = transform;
        fb = transform.GetComponent<FuelBar>();
    }

	void FixedUpdate () {
        float v, h;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // gm.SetSpeed(gm.GetSpeed() + h);
        if (fb.fuel > 0)
        {
            gm.SetSpeedScenery(20 + v * 5f);
            gm.SetSpeedCars(10 + v * 5f);
        }else
        {
            //something to make car stop
        }
        
        
        height = 200 + v * 100;
        side = rb.velocity.x * 50;
        transform.position += new Vector3(h * Time.deltaTime * moveSpeed, 0, 0);
        //rb.AddForce(new Vector3(h * moveSpeed * Time.deltaTime * 100, 0, 0));
        if (Input.GetKeyDown(KeyCode.Space))
            Crash();

        //fuel
        fb.fuel -= 0.002f + v/700;
        
        Debug.Log(v);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit " + collision.collider);
        Crash();
    }
    void Crash() {
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 0.175f, 0), -Vector3.up, out hit);
        GameObject toss;
        toss = Instantiate(playerToss, jumpPoint.transform.position, Quaternion.identity);
        toss.SetActive(true);
        toss.GetComponent<Rigidbody>().AddTorque(new Vector3(90, 0, Random.Range(-10, 10)));
        pToss = toss.GetComponent<PlayerToss>();
        pToss.height = height;
        pToss.side = side;
        //car.transform.parent = hit.transform;
        gm.AddCarToSegment(car);

        cam.GetComponent<CameraFollow>().target = toss;
        gameObject.SetActive(false);

        
    }
}