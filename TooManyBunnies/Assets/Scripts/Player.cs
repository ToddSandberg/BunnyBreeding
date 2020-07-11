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
    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            
            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");

            //assign movement to a single vector3
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);
    
            //normalize movement for diagonal movement
            directionOfMovement = directionOfMovement.normalized * Time.deltaTime * moveSpeed;
            
            // apply movement to player's transform
            gameObject.transform.Translate(directionOfMovement);

            

            
        } 
    }

}
