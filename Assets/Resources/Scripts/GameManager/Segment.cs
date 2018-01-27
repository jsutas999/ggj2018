using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {

    public float speed;
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
          transform.Translate(new Vector3(0, Mathf.Abs(speed) * Time.fixedDeltaTime * 0.08f, 0));
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

    public void Clear()
    {
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
