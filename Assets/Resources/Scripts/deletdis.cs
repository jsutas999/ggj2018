using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletdis : MonoBehaviour {
    public GameObject camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(camera.transform);
        transform.localPosition = new Vector3(0, 0, 10);
	}
}
