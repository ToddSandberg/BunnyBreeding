using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHand;

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.E)) {
			if (this.GetComponent<CircleCollider2D> ().IsTouching (player.GetComponent<CircleCollider2D>())) {
				transform.SetParent(playerHand.transform);
                transform.localPosition = new Vector3(0, 0, -1);
                this.GetComponent<BunnyAI>().bunnySpeed = 0;
			}
		}
    }
}
