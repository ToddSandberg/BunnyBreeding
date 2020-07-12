using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDrive : MonoBehaviour
{
    private int velocity = 1;
    public int leftBound = -7;
    public int rightBound = 7;

    void Update() {
        if (gameObject.transform.position.x < leftBound) {
            velocity = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } else if(gameObject.transform.position.x > rightBound) {
            velocity = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocity, 0, 0);     
    }
}
