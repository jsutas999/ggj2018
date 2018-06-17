using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour {
    public float force, height, side;
    public Rigidbody rb;
    public GameObject player;
    public GameManager gm;
    bool gameOver = false, triggered = false;
    public float move;
    float v, h;
    private Rigidbody[] rbs;

    void Start () {
        rb.AddForce(new Vector3(side, height, force));
        rb.AddTorque(new Vector3(10000, 0, Random.Range(-10, 10)));
        rbs = gameObject.GetComponentsInChildren<Rigidbody>();
    }
    private void Update() {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1")) {
            if (Input.mousePosition.x < Screen.width / 2)
                h = -1;
            else
                h = 1;
            if (Input.mousePosition.y < Screen.height / 2)
                v = -1;
            else
                v = 1;
        }

        if (!gameOver) {
            gm.SetSpeedScenery(20 + v * 5f);
            gm.SetSpeedCars(10 + v * 5f);
        }
    }
    private void FixedUpdate() {
        if (!gameOver) {
            rb.AddForce(new Vector3(h * move, 0, 0));
        }
    }
    public void Collision(bool trigger, GameObject obj) {
        if (!trigger && !gameOver && !triggered) { // Hit anything else
            EnableRagdoll();
            gameOver = true;
            //Debug.Log("HIT ROAD");
            gm.GameOver();
        }
        if (trigger && !gameOver && !triggered) { //Jump into car
            triggered = true;
            player.SetActive(true);
            player.GetComponent<PlayerControll>().Enter(obj.transform.parent.gameObject);
            player.transform.position = new Vector3(rb.position.x, player.transform.position.y, player.transform.position.z); //move player to the x of ragdoll
            Destroy(obj); //Destroy car trigger
            Destroy(gameObject); //Destroy ragdoll
        }
    }
    public void EnableRagdoll() {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = false;
        this.GetComponent<Animator>().enabled = false;
    }
}
