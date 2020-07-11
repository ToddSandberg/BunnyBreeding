using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAI : MonoBehaviour
{
    public float bunnySpeed;
    public float minimumBunnyMoveTime;
    public float maximumBunnyMoveTime;
    public float bunnyMoveChance;

    private CircleCollider2D myCollider;


    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        checkMovement();

        transform.Translate(xSpeed, ySpeed, 0);
    }


    private float xSpeed = 0;
    private float ySpeed = 0;
    private float moveTimer = 3.0f;

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

}
