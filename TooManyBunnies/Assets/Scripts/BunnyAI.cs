using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BunnyAI : MonoBehaviour
{
    public string breed;
    public string gender;
    public float bunnySpeed;
    public float minimumBunnyMoveTime;
    public float maximumBunnyMoveTime;
    public float bunnyMoveChance;
    public float breedTimer;
    public int value;


    private float breedCooldownTime;
    private CircleCollider2D myCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BunnyCreator breedingScript;

    // Start is called before the first frame update
    void Start()
    {
        breedCooldownTime = breedTimer;
        animator = gameObject.GetComponent<Animator>();
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        breedingScript = GameObject.Find("BunnyBreeder").GetComponent<BunnyCreator>();
       if (gender == "Male")
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        checkBow();
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

        if (moveTimer < 0 && UnityEngine.Random.Range(0f, 1f) < bunnyMoveChance)
        {
            moveTimer = UnityEngine.Random.Range(minimumBunnyMoveTime, maximumBunnyMoveTime);
            float angle = UnityEngine.Random.Range(0, 360);
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
            moveTimer = UnityEngine.Random.Range(minimumBunnyMoveTime, maximumBunnyMoveTime);
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (breedCooldownTime < -1 && collision.gameObject.tag == "Bunny")
        {
            breedCooldownTime = breedingScript.breedBunny(gameObject, collision.gameObject);
        }

    }

    private bool previousFlip = false;

    void checkBow()
    {

        if (gender == "Female")
        {
            bool flipDirection = xSpeed > 0;
            if (previousFlip != flipDirection)
            {
                int mult;
                if (flipDirection)
                    mult = 1;
                else
                    mult = -1;

                Transform bow = gameObject.transform.GetChild(1);
                bow.localPosition = new Vector3(mult * Math.Abs(bow.localPosition.x), bow.localPosition.y, bow.localPosition.z);
                bow.GetComponent<SpriteRenderer>().flipX = !bow.GetComponent<SpriteRenderer>().flipX;
            }
            previousFlip = flipDirection;
        }
    }


    void checkAnimation()
    {
        bool flipDirection = false;
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
