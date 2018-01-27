using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawningBehavior : SpawningBehavior
{

    public float RoadWidth = 6f;
    public float DistanceMultiplier = 3f;
    public float startDistFraction = 0.33f;

    public override Vector3 ProcessBounds(Vector3 bounds)
    {
        bounds.z *= DistanceMultiplier;
        return bounds;
    }

    public override Vector3 TransformPositio(Vector3 position)
    {
        position.x = Random.Range(-RoadWidth / 2f, RoadWidth / 2f);
        return position;
    }

    public override float ChangeStartDistance(float dist)
    {
        return dist * startDistFraction;
    }


}
