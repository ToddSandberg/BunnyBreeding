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

    private CircleCollider2D myCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Component breedingScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        breedingScript = GameObject.Find("BunnyBreeder").GetComponent("BunnyCreator");
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        transform.Translate(xSpeed, ySpeed, 0);
        checkAnimation();
    }
    

    private float xSpeed = 0;
    private float ySpeed = 0;
    private float moveTimer = 0f;

    void checkMovement()
    {
        

        if (moveTimer < 0 && Random.Range(0f, 1f) < (.1*bunnyMoveChance))
        {
            moveTimer = Random.Range(minimumBunnyMoveTime, maximumBunnyMoveTime);
            float angle = Random.Range(0, 360);
            xSpeed = bunnySpeed * Mathf.Cos(angle);
            ySpeed = bunnySpeed * Mathf.Sin(angle);
        }
        else if (moveTimer < 0)
        {
            xSpeed = 0;
            ySpeed = 0;
            moveTimer -= Time.deltaTime;
        }
        else
        {

            moveTimer -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bunny")
        {
            float posX = (transform.position.x + collision.transform.position.x) / 2;
            float posY = (transform.position.y + collision.transform.position.y) / 2;
            Debug.Log("Creating bunny at " + posX + ", " + posY);
        } 
    }


    void checkAnimation()
    {
        if (xSpeed != 0 || ySpeed != 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        spriteRenderer.flipX = (xSpeed > 0);
    }

}