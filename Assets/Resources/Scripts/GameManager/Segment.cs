using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {

    public float speed;
    private List<GameObject> obsticles = new List<GameObject>();
    public AnimationCurve curve;
    public float curveDistance, curveMultiplier;
    float curveX = 0, curveY = 0;
    public bool rotate = false;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
        if (Mathf.Abs(transform.localPosition.z) < curveDistance) {
            curveX = Mathf.Abs(transform.localPosition.z / curveDistance);
            curveY = curve.Evaluate(curveX);
            var trans = transform.localPosition;
            trans.y = (curveY - 1) * curveMultiplier;
            transform.localPosition = trans;
            //Debug.Log(curveY);
            //if (rotate) transform.localRotation = Quaternion.Euler(Mathf.Atan2(1-curveY, 1 - curveX) * Mathf.Rad2Deg / 4f, 0, 0);
        }
        else {
            var trans = transform.localPosition;
            trans.y = 0;
            transform.localPosition = trans;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MoveForward(float distance)
    {
        transform.Translate(new Vector3(0, 0, distance));

    }

    public void Clear()
    {
        while(obsticles.Count > 0)
        {
            GameObject o = obsticles[0];
            obsticles.RemoveAt(0);
            Destroy(o);
        }
    }

    public void AddObsticle(GameObject obb)
    {
        obsticles.Add(obb);
    }


}
