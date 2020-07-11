using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHand;
    private bool isBeingHeld;

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.E)) {
            if (isBeingHeld) {
                transform.parent = null;
                this.GetComponent<BunnyAI>().enabled = true;
                isBeingHeld = false;
            } else {
                if (this.GetComponent<CircleCollider2D> ().IsTouching (player.GetComponent<CircleCollider2D>())) {
                    transform.SetParent(playerHand.transform);
                    transform.localPosition = new Vector3(0, 0, -1);
                    this.GetComponent<BunnyAI>().enabled = false;
                    isBeingHeld = true;
                }
            }
		}
    }
}
