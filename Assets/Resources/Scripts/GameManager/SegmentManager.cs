using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentManager : MonoBehaviour {

    public GameObject[] segments;
    public GameObject[] obsticles;

    public float gameSpeed = 1f;
    public float removeDistance = 100f;

    public bool SpawnObjectsInMiddle = false;
    public float SegmentIntersectionFactor = 1f;

    public SpawningBehavior segmentBehavior;
    private float spawnDistance = 9.9f;
    private SpecialQueue<GameObject> spawned = new SpecialQueue<GameObject>();
    private SpecialQueue<GameObject> pool = new SpecialQueue<GameObject>();
    private GameObject lastSpawned = null;
    public RoadObjectsManager roadObjectsManager;

    // Use this for initialization
    void Start () {
        BuildPoolQueue();
        BuildSegments();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawned();
	}


    private void  UpdateSpawned()
    {
        RemoveOutOfBoundsSegment();
        FillSegmentGap();
    }

    private GameObject MakeSegment()
    {
        return segmentBehavior.MakeSegment(this);
    }

   public GameObject ActivateSegment()
   {
        GameObject go = (pool.Count > 0) ? pool.Dequeue() : MakeSegment();
        spawned.Enqueue(go);
        segmentBehavior.ActivateSegment(go,this);
        return go;
   }

    public void SetSpeed(float speed)
    {
        gameSpeed = speed;
        foreach(GameObject o in spawned.GetList())
        {
            o.GetComponent<Segment>().SetSpeed(speed * -1);
        } 

        if(speed < 0)
        {
            removeDistance = 100;
        }
    }

    public float GetSpeed()
    {
        return gameSpeed;
    }

    #region Update

    private void RemoveOutOfBoundsSegment()
    {
        segmentBehavior.RemoveOutOfBoundsSegment(this);
    }

    private void FillSegmentGap()
    {
        segmentBehavior.FillGap(this);
    }
#endregion

    #region START

    private void BuildPoolQueue()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject t = MakeSegment();
            pool.Enqueue(t);
        }
    }

    private void BuildSegments()
    {
        segmentBehavior.BuildSegments(this);
    }
    #endregion

    #region GETTERS/SETTERs
    public GameObject GetLastSpawned()
    {
        return lastSpawned;
    }

    public float GetDistanceToNextSpawn()
    {
        return spawnDistance;
    }

    public void SetDistanceToNextSpawn(float dist)
    {
        this.spawnDistance = dist;
    }


    public void SetLastSpawned(GameObject last)
    {
        lastSpawned = last;
    }

    public GameObject GetOldest()
    {
        if (spawned.Count > 0)
        {
            return spawned.Peek();
        }
        return null;
    }

    public void EnqueuSpawned(GameObject segment)
    {
        spawned.Enqueue(segment);
    }

    public GameObject DequeueSpawned()
    {
        return spawned.Dequeue();
    }

    public void EnqueuePool(GameObject segment)
    {
        pool.Enqueue(segment);
    }

    public GameObject DequeuePool()
    {
        return pool.Dequeue();
    }

    public bool RemoveFromManager(GameObject segment)
    {
        Destroy(segment.GetComponent<Segment>());
        return spawned.Remove(segment);
    }

    public void AddToSegment(GameObject gom)
    {
        gom.AddComponent<Segment>().SetSpeed(gameSpeed * -1);
        if (!gom.GetComponent<Rigidbody>())
        {
            gom.AddComponent<Rigidbody>().isKinematic = true;
        }
        gom.transform.SetParent(transform);
        spawned.Enqueue(gom);
    }


    #endregion
}