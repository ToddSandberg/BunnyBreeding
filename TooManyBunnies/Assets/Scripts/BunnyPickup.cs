﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject playerHand;
    
    private bool isBeingHeld;
    
    
    // For dragging things around
    /*
    private Vector3 screenPoint;
	private Vector3 offset;
	
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}
    */

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isBeingHeld == false) {
            GameObject player = playerHand.transform.parent.gameObject;
            if (this.GetComponent<CircleCollider2D> ().IsTouching(player.GetComponent<CircleCollider2D>())) {
                pickUpBunny(player);
            }
		}

        if (Input.GetMouseButtonDown(1)) {
            GameObject player = playerHand.transform.parent.gameObject;
            if (isBeingHeld) {
                setDownBunny(player);
            }
        }
    }

    void pickUpBunny(GameObject playerObject) {
        transform.SetParent(playerHand.transform);
        transform.localPosition = new Vector3(0, 0, -1);
        this.GetComponent<BunnyAI>().enabled = false;
        playerObject.GetComponent<Inventory>().addBunny(gameObject);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        isBeingHeld = true;
    }

    void setDownBunny(GameObject playerObject) {
        transform.parent = null;
        this.GetComponent<BunnyAI>().enabled = true;
        playerObject.GetComponent<Inventory>().removeBunny(this.GetComponent<BunnyAI>().breed + "-" + this.GetComponent<BunnyAI>().gender);
        isBeingHeld = false;
    }

}
