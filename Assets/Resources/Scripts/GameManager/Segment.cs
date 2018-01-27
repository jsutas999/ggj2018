﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {

    private float speed;

    private List<GameObject> cars = new List<GameObject>();
    private List<GameObject> obsticles = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
        if(transform.localPosition.y < 0)
        {
          transform.Translate(new Vector3(0, -speed * Time.fixedDeltaTime * 0.08f, 0));
        } else
        {
            var t = transform.localPosition;
            t.y = 0;
            transform.localPosition = t;
        }
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
        Vector3 bounds = transform.GetChild(0).GetComponent<Renderer>().bounds.size;
        bounds.Scale(new Vector3(0.75f, 0.75f, 0.75f));
        var dist = (bounds.x * Random.Range(0, 3) / 3) - bounds.x / 3;
        c.transform.localPosition = new Vector3(dist, 0, 0);
        cars.Add(c);
    }

    public void Clear()
    {
        while(cars.Count > 0)
        {
            GameObject o = cars[0];
            cars.RemoveAt(0);
            Destroy(o);
        }

        while(obsticles.Count > 0)
        {
            GameObject o = obsticles[0];
            obsticles.RemoveAt(0);
            Destroy(o);
        }
    }

    public void AddObsticle(GameObject obb)
    {
        obsticles.Add(obb);
    }


}
