using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectsManager : MonoBehaviour
{

    public GameObject[] objects;
    private int SegmentCounter = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void AddDetailToSegment(GameObject segment, Vector3 bounds)
    {
        bounds.Scale(new Vector3 (0.45f,0.45f,0.45f) );

        GameObject t = Instantiate(objects[Random.Range(0, objects.Length)], segment.transform);
        segment.GetComponent<Segment>().AddObsticle(t);

        if (SegmentCounter%2 == 0)
        {
            t.transform.localPosition = new Vector3(bounds.x, 0, 0); 
        } else
        {
            t.transform.localPosition = new Vector3(-bounds.x, 0, 0);
            var angles = t.transform.eulerAngles;
            angles.y += 180;
            t.transform.eulerAngles = angles;
        }
        SegmentCounter++;
    }


}
