using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] roadSegments;
    public float gameSpeed = 0.1f;
    private float timer = 0f;
    public float removeDistance = 100f;
    public float spawnDistance = 9.9f;
    private List<GameObject> spawned = new List<GameObject>();
    private Queue<GameObject> pool = new Queue<GameObject>();

	// Use this for initialization
	void Start () {

        // Builds up queue
        for(int i = 0; i < 20; i++)
        {
            GameObject t = MakeRoudSegment();
            pool.Enqueue(t);
        }

        // Pulls from queue to build road
        for(int i = 0; i < 20; i++)
        {
            GameObject g = ActivateSegmentFromPool();
            g.GetComponent<RoadSegment>().MoveForward(i*spawnDistance);
        }

        

	}
	
	// Update is called once per frame
	void Update () {

        UpdateSpawned();
	}


    private void  UpdateSpawned()
    {
        List<GameObject> forDeletion = new List<GameObject>();

        GameObject nearest = null;
        float nDist = 9999999999999;

        foreach (GameObject spawn in spawned)
        {
            var dist = Vector3.Distance(transform.position, spawn.transform.position);
            if (dist > removeDistance)
            {
                forDeletion.Add(spawn);
            } else if (nDist > dist){
                nearest = spawn;
                nDist = dist;
            }
        }

        if(nearest != null)
        {
            if(nDist > spawnDistance)
            {
                ActivateSegmentFromPool();
            }
        }


        foreach(GameObject d in forDeletion)
        {
            spawned.Remove(d);
            d.SetActive(false);
            pool.Enqueue(d);
        }
    }

    private GameObject MakeRoudSegment()
    {
        var t = Random.Range(0, roadSegments.Length);
        GameObject roadSegment = Instantiate(roadSegments[t]);
        roadSegment.SetActive(false);
        roadSegment.transform.position = transform.position;
        roadSegment.transform.SetParent(transform);
        roadSegment.GetComponent<RoadSegment>().SetSpeed(gameSpeed);
        return roadSegment;
    }

   private GameObject ActivateSegmentFromPool()
   {
        GameObject go = (pool.Count > 0) ? pool.Dequeue() : MakeRoudSegment();
        go.SetActive(true);
        go.transform.position = transform.position;
        spawned.Add(go);
        return go;
   }

}
