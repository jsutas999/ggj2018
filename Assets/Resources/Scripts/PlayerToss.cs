using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour {
    public float force, height, side;
    public Rigidbody rb;
    public GameObject playerControll;
    public GameObject cam;
    public GameManager gm;
    bool gameOver = false;
	void Start () {
        rb.AddForce(new Vector3(side, height, force));
        rb.AddTorque(new Vector3(10000, 0, Random.Range(-10, 10)));
    }
    public void RoadCollision()
    {
        gameOver = true;
        //Debug.Log("HIT ROAD");
        gm.SetSpeedScenery(0);
        gm.SetSpeedCars(-10);
    }
    public void TopCollision(GameObject other)
    {
        if (!gameOver)
        {
            playerControll.SetActive(true);
            playerControll.transform.position = other.transform.position;
            playerControll.GetComponent<PlayerControll>().car = other;
            Destroy(other.GetComponent<Rigidbody>());
            other.transform.parent = playerControll.transform; //set car as child of Player
            cam.GetComponent<CameraFollow>().target = playerControll;
            gm.RemoveCarFromSegment(other);
            Destroy(gameObject);
        }

    }
}
