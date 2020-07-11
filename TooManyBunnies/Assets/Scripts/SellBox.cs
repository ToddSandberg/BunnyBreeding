using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBox : MonoBehaviour
{

    private BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Deletes bunnies if they touch the box
        if (collision.gameObject.tag == "Bunny") {
            Destroy(collision.gameObject);
        }
        
    }
}
