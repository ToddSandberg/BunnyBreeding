using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject playerHand;
    private bool isBeingHeld;

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.E)) {
            GameObject player = playerHand.transform.parent.gameObject;
            if (isBeingHeld) {
                transform.parent = null;
                this.GetComponent<BunnyAI>().enabled = true;
                player.GetComponent<Inventory>().removeBunny(this.GetComponent<BunnyAI>().breed + "-" + this.GetComponent<BunnyAI>().gender);
                isBeingHeld = false;
            } else {
                if (this.GetComponent<CircleCollider2D> ().IsTouching (player.GetComponent<CircleCollider2D>())) {
                    transform.SetParent(playerHand.transform);
                    transform.localPosition = new Vector3(0, 0, -1);
                    this.GetComponent<BunnyAI>().enabled = false;
                    player.GetComponent<Inventory>().addBunny(gameObject);
                    isBeingHeld = true;
                }
            }
		}
    }
}
