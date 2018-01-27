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
    }


}
