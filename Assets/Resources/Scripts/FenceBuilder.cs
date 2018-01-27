using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBuilder : MonoBehaviour {

    public GameObject fence;
    public GameObject asc_chunk;
    public GameObject chunk;
    public GameObject desc_chunk;

    private GameObject currFence;
    private GameObject curr_asc_chunk;
    private GameObject curr_chunk;
    private GameObject curr_desc_chunk;
    private bool firstChunk = false;

    public int fencesCount = 0;
	// Use this for initialization
	void Start () {
        //fence = fence.GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Debug.Log(Input.inputString);
            switch (Input.inputString)
            {
                case "q": //create new fence
                    currFence = newFence();
                    fencesCount++;
                    break;
                case "a":
                    curr_asc_chunk = Instantiate(asc_chunk, currFence.transform) as GameObject;
                    break;
                case "s":
                    
                    if (!firstChunk) //if first
                    {
                        //Transform firstJoint = curr_asc_chunk.GetComponentInChildren<Transform>().transform.Find("up_joint").GetComponent<Transform>();
                        curr_chunk = Instantiate(chunk, currFence.transform.position, Quaternion.identity, currFence.transform) as GameObject;
                        curr_chunk.transform.GetChild(0).transform.eulerAngles = new Vector3(-90, 0, 0);
                        firstChunk = true;
                    }else
                    {
                        //Transform frontJoint = curr_chunk.transform.Find("end_joint").GetComponent<Transform>();
                        curr_chunk = Instantiate(chunk, curr_chunk.transform.position , Quaternion.identity, currFence.transform) as GameObject;
                        curr_chunk.transform.GetChild(0).transform.eulerAngles = new Vector3(-90, 0, 0);
                    }
                    
                    break;
                case "d":

                    break;
            }
        }
		
	}

    private GameObject newFence()
    {
        return Instantiate(fence, new Vector3(fencesCount * 3, 0,0), Quaternion.identity) as GameObject;
    }
}
