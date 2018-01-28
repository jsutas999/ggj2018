using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour {
    public float force, height, side;
    public Rigidbody rb;
    public GameObject player;
    public GameObject cam;
    public GameManager gm;
    bool gameOver = false;
    public float move;
    float v, h;
    private Rigidbody[] rbs;

    void Start () {
        rb.AddForce(new Vector3(side, height, force));
        rb.AddTorque(new Vector3(10000, 0, Random.Range(-10, 10)));
        rbs = gameObject.GetComponentsInChildren<Rigidbody>();
    }
    private void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(h * move, 0, 0));
        if (!gameOver) {
            gm.SetSpeedScenery(20 + v * 5f);
            gm.SetSpeedCars(10 + v * 5f);
        }
    }
    public void RoadCollision() {
        EnableRagdoll();
        if (!gameOver) {
            gameOver = true;
            Debug.Log("HIT ROAD");
            SendMessage("GameOver");
            gm.SetSpeedScenery(0);
            gm.SetSpeedCars(-10);
        }
    }
    public void TopTrigger(GameObject other) {
        if (!gameOver) {
            player.SetActive(true);
            other.transform.parent.transform.position = player.transform.position;
            other.transform.parent.parent = player.transform; //set car as child of Player
            player.transform.position = new Vector3(rb.position.x, player.transform.position.y, player.transform.position.z);
            player.GetComponent<PlayerControll>().car = other;
            Destroy(other.transform.parent.GetComponent<Rigidbody>());
            
            cam.GetComponent<CameraFollow>().target = player;
            gm.RemoveCarFromSegment(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
    public void EnableRagdoll() {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = false;
        this.GetComponent<Animator>().enabled = false;
    }
}
