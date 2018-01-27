using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public SegmentManager RoadSegmentManager;
    public SegmentManager TerrainSegmentManager;
    public SegmentManager CarSegmentManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetSpeed(float speed)
    {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
        CarSegmentManager.SetSpeed(speed);
    }

    public float GetSpeed()
    {
        return RoadSegmentManager.GetSpeed();
    }
}
