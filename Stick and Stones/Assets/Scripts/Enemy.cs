using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private Animator anim;
    public GameObject hitEffect;

    private float dazedTime = 0.6f;
    public float startDazedTime;

    private GameObject player;

    public Transform[] patrolPoints;
    public int patrolDestination;

    public Transform target;
    public bool isChasing;
    public float chaseDistance;

    public float jumpHeight = 7f;
    private Rigidbody2D rb;
    public float jumpInterval = 5f;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // anim.SetBool("isRunning", true); no animator yet
        rb = GetComponent<Rigidbody2D>();

        //jump periodically
        InvokeRepeating("Jump", 0f, jumpInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.left * speed * Time.deltaTime); //temp movement for enemy
        if (KBCounter <= 0){
            speed = 2.5f;
        }
        else {
            if (KnockFromRight){
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (!KnockFromRight){
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }

        if (dazedTime<=0){
            speed = 2.5f;
        }
        else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        
        //chase and patrol behaviour
        if (isChasing){
            //chase target right
            if (transform.position.x > target.transform.position.x){
                transform.localScale = new Vector3(2,2,2);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            //chase target left
            if (transform.position.x < target.transform.position.x){
                transform.localScale = new Vector3(-2,2,2);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Vector2.Distance(transform.position, target.position) > 8){
                isChasing = false;
            }
        }
        else {
            //player will be chased if close
            if (Vector2.Distance(transform.position, target.position) < chaseDistance){
                isChasing = true;
            }
            //patrol behaviour
            if (patrolDestination == 0){
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.5f){
                    // transform.localScale = new Vector3(-2,2,2);
                    Flip();
                    patrolDestination = 1;
                }
            }
            if (patrolDestination == 1){
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.5f){
                    // transform.localScale = new Vector3(2,2,2);
                    Flip();
                    patrolDestination = 0;
                }
            }
        }

    }

    public void DamageTaken(int damage){
        dazedTime = startDazedTime;

        // Instantiate(hitEffect, transform.position, Quaternion.identity); no hiteffect yet
        health -= damage;
        Debug.Log("Enemy Damaged!");
        KBCounter = KBTotalTime;
        if (target.position.x <= transform.position.x){
            KnockFromRight = false;
        }
        else if (target.position.x > transform.position.x){
            KnockFromRight = true;
        }
        if (health<=0){
            Destroy(this.gameObject);
        }
    }

    private void Flip(){
        if (transform.localScale == new Vector3(2,2,2)){
            transform.localScale = new Vector3(-2,2,2);
        }
        else if (transform.localScale == new Vector3(-2,2,2)){
            transform.localScale = new Vector3(2,2,2);
        }
    }

    void Jump()
    {
         Vector2 velocity = rb.velocity;
         velocity.y = jumpHeight;
         rb.velocity = velocity;
    }

}
