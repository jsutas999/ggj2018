using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public SegmentManager RoadSegmentManager;
    public SegmentManager TerrainSegmentManager;
    public SegmentManager CarSegmentManager;

    public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Depricated
    public void SetSpeed(float speed)
    {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
        CarSegmentManager.SetSpeed(speed);
    }

    // Depricated
    public float GetSpeed()
    {
        return RoadSegmentManager.GetSpeed();
    }

    public float GetSpeedScenery()
    {
        return RoadSegmentManager.GetSpeed();
    }

    public float GetSpeedCars()
    {
        return CarSegmentManager.GetSpeed();
    }

    public void SetSpeedScenery(float speed)
    {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
    }

    public void SetSpeedCars(float speed)
    {
        CarSegmentManager.SetSpeed(speed);
    }

    public void RemoveCarFromSegment(GameObject car)
    {
        CarSegmentManager.RemoveFromManager(car);
        scoreManager.AddScoreOnCarJump();
    }

    public void AddCarToSegment(GameObject car)
    {
        CarSegmentManager.AddToSegment(car);
    }


}
