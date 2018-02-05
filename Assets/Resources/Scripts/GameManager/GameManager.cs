using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public SegmentManager RoadSegmentManager;
    public SegmentManager TerrainSegmentManager;
    public SegmentManager CarSegmentManager;

    public ScoreManager scoreManager;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    // Depricated
    public void SetSpeed(float speed)
    {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
        CarSegmentManager.SetSpeed(speed);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 300, 20), "" + Input.gyro.attitude);
        GUI.Label(new Rect(20, 40, 300, 20), "Update: " + Mathf.Floor(1 /Time.deltaTime));
        GUI.Label(new Rect(20, 60, 300, 20), "FixedUpdate: " + Mathf.Floor(1/Time.fixedDeltaTime));
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
        //scoreManager.AddScoreOnCarJump();
    }

    public void AddCarToSegment(GameObject car)
    {
        CarSegmentManager.AddToSegment(car);
    }


}
