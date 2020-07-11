using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    public GameObject runningSmoke;


    // Start is called before the first frame update
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
 
            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        
            //assign movement to a single vector3
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);
        
            // apply movement to player's transform
            gameObject.transform.Translate(directionOfMovement);

            print("hello");

            //Hai alex
            animator.SetBool("walking", true);
        } else {
            animator.SetBool("walking", false);
        }
    }
}
