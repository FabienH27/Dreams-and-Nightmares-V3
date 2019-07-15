using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private Vector3 p1;
    private Vector3 p2;
    public float speed;
    public Transform point1;
    public Transform point2;

	// Use this for initialization
	void Start () {

        p1 = point1.position;
        p2 = point2.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        float dist = 1f / Vector3.Distance(p1, p2);
        transform.position = Vector3.Lerp(p1, p2, Mathf.PingPong(Time.time * speed * dist, 1.0f));

    }
}
