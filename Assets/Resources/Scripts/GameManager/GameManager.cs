using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] roadSegments;
    public GameObject[] cars;
    public float gameSpeed = 0.1f;
    public float removeDistance = 100f;
    public float spawnDistance = 9.9f;


    private Queue<GameObject> spawned = new Queue<GameObject>();
    private Queue<GameObject> pool = new Queue<GameObject>();
    private GameObject lastSpawned = null;

	// Use this for initialization
	void Start () {
        BuildPoolQueue();
        BuildRoad();
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

    private GameObject MakeRoudSegment()
    {
        var t = Random.Range(0, roadSegments.Length);
        GameObject roadSegment = Instantiate(roadSegments[t]);
        roadSegment.SetActive(false);
        roadSegment.transform.position = transform.position;
        roadSegment.transform.SetParent(transform);
        RoadSegment rs = roadSegment.GetComponent<RoadSegment>();
        rs.SetSpeed(gameSpeed * -1);     
        return roadSegment;
    }

   private GameObject ActivateSegmentFromPool()
   {
        GameObject go = (pool.Count > 0) ? pool.Dequeue() : MakeRoudSegment();
        spawned.Enqueue(go);
        lastSpawned = go;

        go.SetActive(true);
        go.transform.position = transform.position;

        RoadSegment rs = go.GetComponent<RoadSegment>();
        rs.Clear();
        rs.AddCar(Instantiate(cars[0], go.transform));

        return go;
   }


    #region Update

    private void RemoveOutOfBoundsSegment()
    {
        GameObject oldest = spawned.Peek();
        var dist = Vector3.Distance(transform.position, oldest.transform.position);
        if (dist > removeDistance)
        {
            pool.Enqueue(spawned.Dequeue());
            oldest.SetActive(false);
        }
    }

    private void FillSegmentGap()
    {
        var dist = Vector3.Distance(transform.position, lastSpawned.transform.position);
        if(dist > spawnDistance)
        {
            ActivateSegmentFromPool();
        }
    }
#endregion

    #region START

    private void BuildPoolQueue()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject t = MakeRoudSegment();
            pool.Enqueue(t);
        }
    }

    private void BuildRoad()
    {
        for (int i = 19; i > 0; i--)
        {
            GameObject g = ActivateSegmentFromPool();
            g.GetComponent<RoadSegment>().MoveForward(-i * spawnDistance);
        }
    }
#endregion

}