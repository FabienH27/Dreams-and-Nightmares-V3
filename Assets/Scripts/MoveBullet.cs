using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public int moveSpeed = 50;
    private TrailRenderer trail;


    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 0.75f);
        trail.GetComponent<TrailRenderer>().startWidth = 0.5f;
        trail.GetComponent<TrailRenderer>().endWidth = 0.3f;
    }
}
