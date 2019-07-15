using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesInstances : MonoBehaviour {

    int maxEnemy = 10;
    int enemyCount;
    public GameObject player;
    public float offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        if (enemyCount >= maxEnemy) return;
        player.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        Instantiate(gameObject,player.transform.position,Quaternion.identity);
        enemyCount++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Lava")
        {
            Spawn();
        }
    }
}
