using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunCycle : MonoBehaviour {
    public float sunDistanceFromCamera = 20f;
    public float sunRotationSpeed = 10f;

	// Use this for initialization
	void Start () {
        transform.eulerAngles = new Vector3(0, 0, 0);   
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0.05f, 0, 0));
    }

    
}
