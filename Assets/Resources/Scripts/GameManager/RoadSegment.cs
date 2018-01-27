using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegment : MonoBehaviour {

    private float speed;

    private List<GameObject> cars = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime ));
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MoveForward(float distance)
    {
        transform.Translate(new Vector3(0, 0, distance));

    }

    public void AddCar(GameObject c)
    {
        cars.Add(c);
    }


}
