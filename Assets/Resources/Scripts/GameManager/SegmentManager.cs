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

    private float spawnDistance = 9.9f;
    private Queue<GameObject> spawned = new Queue<GameObject>();
    private Queue<GameObject> pool = new Queue<GameObject>();
    private GameObject lastSpawned = null;
    private RoadObjectsManager roadObjectsManager;

    // Use this for initialization
    void Start () {

        roadObjectsManager = GetComponent<RoadObjectsManager>();

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
        var t = Random.Range(0, segments.Length);
        GameObject roadSegment = Instantiate(segments[t],transform);
        roadSegment.SetActive(false);
        return roadSegment;
    }

   private GameObject ActivateSegment()
   {
        GameObject go = (pool.Count > 0) ? pool.Dequeue() : MakeSegment();
        spawned.Enqueue(go);
        go.SetActive(true);
        var bounds = go.transform.GetChild(0).transform.GetComponent<Renderer>().bounds.size;

        if(lastSpawned != null)
        {
            var travel = lastSpawned.transform.localPosition.z;
            var t = transform.transform.localPosition;
            t.z = travel + bounds.z * SegmentIntersectionFactor;
            t.y = -10;
            go.transform.localPosition = t;
        } else
        {
            go.transform.localPosition = new Vector3(0, -10, -removeDistance);
        }
        

        Segment rs = go.GetComponent<Segment>();
        if(SpawnObjectsInMiddle)
        {
            rs.Clear();
            rs.AddCar(Instantiate(obsticles[0], go.transform));
            roadObjectsManager.AddDetailToSegment(go, bounds);
        }

        rs.SetSpeed(gameSpeed * -1);

        var dist = bounds.z - 0.03f; 
        spawnDistance = dist;

        lastSpawned = go;

        return go;
   }

    public void SetSpeed(float speed)
    {
        gameSpeed = speed;
        foreach(GameObject o in spawned)
        {
            o.GetComponent<Segment>().SetSpeed(speed * -1);
        } 
    }

    public float GetSpeed()
    {
        return this.gameSpeed;
    }

    #region Update

    private void RemoveOutOfBoundsSegment()
    {
        var d = 0f;
        do
        {
            
            GameObject oldest = spawned.Peek();
            var dist = Mathf.Abs(oldest.transform.localPosition.z);
            if (dist > removeDistance)
            {
                pool.Enqueue(spawned.Dequeue());
                oldest.SetActive(false);
            }
        } while (d > removeDistance);

    }

    private void FillSegmentGap()
    {
        var dist = Mathf.Abs(lastSpawned.transform.localPosition.z);
        if(dist > spawnDistance)
        {
           ActivateSegment();
        }
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
        int t = 0;
        GameObject g = ActivateSegment();
        while(g.transform.localPosition.z < -20)
        {
            g = ActivateSegment();
            if(t < 10)
            {
                g.GetComponent<Segment>().Clear();

                t++;
            }
            var o = g.transform.localPosition;
            o.y = 0;
            g.transform.localPosition = o;
           
        }
    }
#endregion

}