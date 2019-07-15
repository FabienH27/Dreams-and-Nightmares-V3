using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAroundPoint : MonoBehaviour {

    public Transform pivotSquare;

    public float angle;
	// Update is called once per frame
	void Update () {

            //radiusGems[i].transform.RotateAround(pivotSquare.transform.position, Vector3.forward, angle);
            transform.position = RotatePointAroundPivot(transform.position, pivotSquare.transform.position,Quaternion.Euler(0, 0, angle));

    }
 public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }
}
