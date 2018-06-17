using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedCar : MonoBehaviour {
    public float speed;
    float time = 0;
	void FixedUpdate () {
        time += Time.deltaTime;
        transform.Translate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
        if (time > 3)
            Destroy(this.gameObject);
    }
}
