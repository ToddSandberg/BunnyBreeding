﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAI : MonoBehaviour
{
    public string breed;
    public string gender;
    public float bunnySpeed;
    public float minimumBunnyMoveTime;
    public float maximumBunnyMoveTime;
    public float bunnyMoveChance;
    public float breedTimer;


    public float breedCooldownTime;
    private CircleCollider2D myCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BunnyCreator breedingScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        breedingScript = GameObject.Find("BunnyBreeder").GetComponent<BunnyCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        breedCooldown();
    }

    // Cooldown time between bunnies breeding
    void breedCooldown()
    {
        if (gender == "Female")
            breedCooldownTime -= Time.deltaTime;
    }


    private float xSpeed = 0;
    private float ySpeed = 0;
    private float moveTimer = 0f;

    void checkMovement()
    {

        if (moveTimer < 0 && Random.Range(0f, 1f) < bunnyMoveChance)
        {
            moveTimer = Random.Range(minimumBunnyMoveTime, maximumBunnyMoveTime);
            float angle = Random.Range(0, 360);
            xSpeed = bunnySpeed * Mathf.Cos(angle);
            ySpeed = bunnySpeed * Mathf.Sin(angle);
            GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
            checkAnimation();
        }
        else if (moveTimer < 0)
        {
            xSpeed = 0;
            ySpeed = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
            checkAnimation();
            moveTimer = Random.Range(minimumBunnyMoveTime, maximumBunnyMoveTime);
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Checking breeding from " + gameObject.tag);
        Debug.Log("Checking breeding from " + collision.gameObject.tag);
        Debug.Log(breedCooldownTime);
        if (breedCooldownTime < 0 && collision.gameObject.tag == "Bunny")
        {
            Debug.Log("Checking breeding from " + gameObject.name);
            breedCooldownTime = breedingScript.breedBunny(gameObject, collision.gameObject);
        }

    }


    private bool flipDirection;

    void checkAnimation()
    {
        if (xSpeed != 0 || ySpeed != 0)
        {
            animator.SetBool("walking", true);
            flipDirection = (xSpeed > 0);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        spriteRenderer.flipX = flipDirection;

    }

}
