using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    private Rigidbody rb;
    public float moveSpeed = 1;
    public float height, side;
    public float driveSpeed = 20;
    public float fuelUse;
    public GameObject car;
    public GameObject playerToss;
    public GameObject cam;
    public GameObject jumpPoint;
    public GameManager gm;
    public ScoreManager score;
    float jump;
    bool crashed = false;

    float v = 0, h = 0;
    bool jumpPressed = false;

    void Start () {
        rb = GetComponent<Rigidbody>();
        car.transform.parent = transform;
    }

    private void Update() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire1")) {
            h = Input.mousePosition.x / Screen.width * 2 - 1;
            v = Input.mousePosition.y / Screen.height * 2 - 1;
        }

        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.J))
            score.CollectCoin(1);
    }

    void FixedUpdate () {
        
        gm.SetSpeedScenery(driveSpeed + v * 5f);
        gm.SetSpeedCars(driveSpeed - 10f + v * 5f);

        jump = (height + v) * 1000;

        //transform.position += new Vector3(h * Time.deltaTime * moveSpeed, 0, 0);
        rb.AddForce(new Vector3(h * moveSpeed * Time.fixedDeltaTime * 100, 0, 0));
        side = rb.velocity.x * 50;

        if (jumpPressed) {
            jumpPressed = false;
            Crash();
        }
      
        v = h = 0f;

    }
        private void OnCollisionEnter(Collision collision)
    {
        if (!crashed)
            if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Obstacle")
                Crash();
        //Debug.Log("Hit " + collision.collider);
    }
    void Crash() {
        score.CrashCar();
        crashed = true;
        PlayerToss pToss;
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
    public void Enter(GameObject newCar)
    {
        rb.velocity = Vector3.zero;
        score.EnterCar();
        crashed = false;
        car = newCar;
        car.GetComponentInChildren<ParticleSystem>().Play();
        car.transform.position = transform.position;
        car.transform.parent = transform; //set new car as child of Player
        Destroy(car.GetComponent<Rigidbody>());
        cam.GetComponent<CameraFollow>().target = this.gameObject;
        gm.RemoveCarFromSegment(car);
    }
}