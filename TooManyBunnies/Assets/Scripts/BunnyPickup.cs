﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject playerHand;
    
    private bool isBeingHeld = false;
    
    
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
    }

    private void pickUpBunny(GameObject playerObject) {
        playerObject.GetComponent<Inventory>().addBunny(gameObject);
        gameObject.SetActive(false);
    }

}
