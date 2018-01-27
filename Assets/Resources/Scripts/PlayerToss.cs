using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour {
    public float force, height;
    private Rigidbody rb;
    public GameObject playerControll;
    public GameObject cam;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, height, force));
    }
    private void OnTriggerEnter(Collider other) {
        playerControll.SetActive(true);
        playerControll.transform.position = other.transform.position;
        playerControll.GetComponent<PlayerControll>().car = other.gameObject;
        other.transform.parent = playerControll.transform;
        cam.GetComponent<CameraFollow>().target = playerControll;
        Destroy(gameObject);
    }
}
