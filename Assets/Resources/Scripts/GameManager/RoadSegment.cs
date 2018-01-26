using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegment : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MoveForward(float distance)
    {
        transform.Translate(new Vector3(distance, 0, 0));

    }


}
