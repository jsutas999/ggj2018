using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawningBehavior : MonoBehaviour {

    public virtual GameObject ActivateSegment(GameObject segment, SegmentManager sm)
    {
        segment.SetActive(true);
        Vector3 bounds;
        try
        {
            bounds = segment.transform.GetChild(0).transform.GetComponent<Renderer>().bounds.size;
        } catch
        {
            bounds = segment.GetComponent<BoxCollider>().bounds.size;
        }

        bounds = ProcessBounds(bounds);

        if (sm.GetLastSpawned() != null)
        {
            var travel = sm.GetLastSpawned().transform.localPosition.z;
            var t = transform.transform.localPosition;
            t.z = travel + bounds.z * sm.SegmentIntersectionFactor;
            t.y = -10;
            segment.transform.localPosition = t;
        }
        else
        {
            segment.transform.localPosition = new Vector3(0, -10, ChangeStartDistance (-sm.removeDistance) );
        }

        segment.transform.localPosition = TransformPosition(segment.transform.localPosition);

        Segment rs = segment.GetComponent<Segment>();
        if (sm.SpawnObjectsInMiddle)
        {
            rs.Clear();
            if (sm.roadObjectsManager)
            {
                sm.roadObjectsManager.AddDetailToSegment(segment, bounds);
            }
            
        }

        rs.SetSpeed(sm.gameSpeed * -1);

        var dist = bounds.z - 0.03f;
        sm.SetDistanceToNextSpawn(dist);

        segment.SetActive(true);

        sm.SetLastSpawned(segment);

        return segment;

    }

    public virtual void BuildSegments(SegmentManager sm)
    {
        GameObject g = sm.ActivateSegment();
        while (g.transform.localPosition.z < -20)
        {
            var o = g.transform.localPosition;
            o.y = 0;
            g.transform.localPosition = o;
            g = sm.ActivateSegment();
        }
    }

    public virtual void FillGap(SegmentManager sm)
    {
        if (sm.GetLastSpawned().transform.localPosition.z > 0) return;
        var dist = Mathf.Abs(sm.GetLastSpawned().transform.localPosition.z);

        if (dist > sm.GetDistanceToNextSpawn())
        {
            sm.ActivateSegment();
        }
    }

    public virtual GameObject MakeSegment(SegmentManager sm)
    {
        var t = Random.Range(0, sm.segments.Length);
        GameObject roadSegment = Instantiate(sm.segments[t], transform);
        roadSegment.SetActive(false);
        return roadSegment;
    }

    public virtual void RemoveOutOfBoundsSegment(SegmentManager sm)
    {
        var d = 0f;
        do
        {

            GameObject oldest = sm.GetOldest();
            if (oldest == null) return;
            float dist = 0f;
              
            dist = Mathf.Abs(oldest.transform.localPosition.z);

            if (dist > sm.removeDistance)
            {
                sm.EnqueuePool((sm.DequeueSpawned()));
                oldest.SetActive(false);
            }
        } while (d > sm.removeDistance);
    }


    public virtual Vector3 ProcessBounds(Vector3 bounds)
    {
        return bounds;
    }

    public virtual Vector3 TransformPosition(Vector3 position)
    {
        return position;
    }

    public virtual float ChangeStartDistance(float dist)
    {
        return dist;
    }

}
