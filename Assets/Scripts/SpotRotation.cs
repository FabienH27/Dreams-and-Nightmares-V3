using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotRotation : MonoBehaviour {

    public float rotationAngleMax;
    public float rotationAngleMin;
    public float rotateSpeed = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.PingPong(Time.time * rotateSpeed, 30.0f));



    }
}
