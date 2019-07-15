using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 10;
    public Transform BulletTrailPrefab;
    float timeToFire = 0;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    Transform firePoint;

    // Use this for initialization
    void Awake () {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No Firepoint = what ??");
        }

        
    }
    // Update is called once per frame
    void Update () {
            if (fireRate == 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
	}
    void Shoot() {
        if (Time.time >= timeToSpawnEffect)
            {
                Effect();
                timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            }
        
    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
