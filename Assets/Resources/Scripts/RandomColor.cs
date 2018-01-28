using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {
    public GameObject body;
    public Material[] mats;

    void Start ()
    {
        body.GetComponent<Renderer>().material = mats[Random.Range(0, 8)];
    }
}
