using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    new private AudioSource audio;
    private bool isPlayingSound = false;

    // Start is called before the first frame update
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
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

            spriteRenderer.flipX = Input.GetKey("right") || Input.GetKey("d");

            //Hai alex
            animator.SetBool("walking", true);
            playWalkingSound(true);
        } 
        else {
            animator.SetBool("walking", false);
            playWalkingSound(false);
        }
    }


    private void playWalkingSound(bool walking) {
        if (walking && isPlayingSound) {
            return;
        }
        else if (walking) {
            audio.Play();
            isPlayingSound = true;
        }
        else if (isPlayingSound) {
            audio.Stop();
            isPlayingSound = false;
        }
    }
}
