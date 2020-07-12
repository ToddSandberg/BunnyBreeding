using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBox : MonoBehaviour
{

    private BoxCollider2D myCollider;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Deletes bunnies if they touch the box
        if (collision.gameObject.tag == "Bunny") {
            //TODO get correct gold amount
            BunnyStats.setGold(BunnyStats.getGold() + collision.gameObject.GetComponent<BunnyAI>().value);
            Destroy(collision.gameObject);
            BunnyStats.removeBunny(collision.gameObject.GetComponent<BunnyAI>().breed);
        }
    }
}
