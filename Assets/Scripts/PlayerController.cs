using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    private Animator anim;
    public bool isGrounded;
    private Rigidbody2D rb;
    public float power = 12.5f;
    public Transform bullet;
    public MoveBullet BulletMovement;
    public GameObject Lights;
    public GameObject Spotlight;

    public GameObject ExplosionParticle;

    public Animator UI;
    public GameObject Pause;

    public bool playerDeath;

    public float startHealth;
    private float health;

    private CameraShake camShake;

    public Image HealthBar;
    public Text HealthText;


    public GameObject EndLights;

    public Image test;

    bool jump = false;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        Spotlight.SetActive(false);
        Lights = GameObject.Find("Light");
        health = startHealth;
        HealthText.ToString();
        HealthText.text = "Health : " + health;
        playerDeath = false;
        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        test.gameObject.SetActive(false);
     
		
	}
     void Update()
    {
        HealthBar.fillAmount = health / startHealth;
        HealthText.text = "Health : " + health ;

        if(health == 0)
        {
            StartCoroutine(PlayerDeath());
        }
    }

    IEnumerator PlayerDeath()
    {
        playerDeath = true;
        UI.SetTrigger("GameOver");
        Instantiate(ExplosionParticle, transform.position, transform.rotation);
        StartCoroutine(camShake.Shake(.4f, .2f));
        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (playerDeath == false)
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded == true)
            {
                    anim.SetTrigger("Jump");
                    StartCoroutine(Jump());
            }


            float move = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(move, 0, 0);

            if (move < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                anim.SetTrigger("Run");
                bullet.transform.localScale = new Vector3(-1, 1, 1);
                BulletMovement.moveSpeed = -100;

            }
            if (move > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                bullet.transform.localScale = new Vector3(1, 1, 1);
                BulletMovement.moveSpeed = 100;
                anim.SetTrigger("Run");
            }
            if (move != 0)
            {
                anim.SetTrigger("Run");
            }
            if(move < 0.0001f && move > -0.0001f)
            {
                anim.SetTrigger("Idle");
            }
        }
    }

    IEnumerator Jump()
    {
        new WaitForSeconds(10f);
        rb.velocity = new Vector3(0, power, 0);
        yield return new WaitForSeconds(10f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if(other.gameObject.tag == "FloatPlatform")
        {
            isGrounded = true;
            transform.parent = other.transform;
        }
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        if(other.gameObject.tag == "FloatPlatform")
        {
            transform.parent = null;
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "WeirdZone")
        {
            transform.position = new Vector3(85, 3, 0);
            StartCoroutine(Transition());
        }
        if(other.tag == "Shutdown")
        {
            Lights.SetActive(false);
            Spotlight.SetActive(true);
            Spotlight.GetComponent<Animator>().SetTrigger("Start");
        }

        if(other.tag == "BulletEnemy")
        {
            health -= 1;
        }

        if(other.tag == "Lava")
        {
            health = 0;
        }

        if(other.tag == "EndTrigger")
        {
            Spotlight.SetActive(false);
            EndLights.SetActive(true);
            UI.GetComponent<Animator>().SetTrigger("Finished");
        }
    }

    IEnumerator Transition()
    {
        Debug.Log("work");
        test.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        test.gameObject.SetActive(false);
    }
}
