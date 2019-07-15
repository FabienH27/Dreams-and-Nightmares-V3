 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;
    public GameObject player;
    public float DistY;
    public float distX;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX + distX, posY + DistY, transform.position.z);
    }
}
