using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour {

    public Transform target;
    public Transform rotateEyes;
    public Transform baseEyes;
    public Transform leftEye;
    public Transform rightEye;
    public GameObject ExplosionParticle;
    public Transform firePoint;
    private float health;
    public float startHealth;

    private SpriteRenderer Body;
    private SpriteRenderer Bottom;
    public Color colorRed;

    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    public GameObject BulletTrailPrefab;
    private Vector2 direction;
    private PlayerController playerCtrl;

    private CameraShake camShake;

    public float speed;

    public Image Healthbar;

    // Use this for initialization
    void Start () {
        startHealth = 5;
        health = startHealth;
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        Bottom = transform.Find("Tentacles").GetComponent<SpriteRenderer>();
        Body = transform.Find("Body").GetComponent<SpriteRenderer>();
        Bottom.color = Color.white;
        Body.color = Color.white;
		
	}
	
	// Update is called once per frame
	void Update () {

        Healthbar.fillAmount = health / startHealth;

        if(playerCtrl.playerDeath == false)
        {
            direction = target.position - transform.position;
            float angleWithPlayer = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            if (direction.x > -10 && direction.x < 10)
            {
                Shoot();
            }
            if (direction.x > -20)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            rotateEyes.rotation = Quaternion.AngleAxis(angleWithPlayer, Vector3.forward);
            baseEyes.localRotation = Quaternion.AngleAxis(-angleWithPlayer, Vector3.forward);
            leftEye.localRotation = Quaternion.AngleAxis(angleWithPlayer, Vector3.forward);
            rightEye.localRotation = Quaternion.AngleAxis(angleWithPlayer, Vector3.forward);
        }
        if(health ==  0)
        {
            StartCoroutine(camShake.Shake(.4f,.2f));
            Instantiate(ExplosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
    void Shoot()
    {
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            StartCoroutine(ColorChange());
            health -= 1; 
        }
    }

    IEnumerator ColorChange()
    {
        Bottom.color = colorRed;
        Body.color = colorRed;
        yield return new WaitForSeconds(.1f);
        Bottom.color = Color.white;
        Body.color = Color.white;
        yield break;
    }
}
