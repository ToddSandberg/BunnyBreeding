﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHand;
    
    
    private bool isBeingHeld;
    
    float distance = 10f;

    private Vector3 screenPoint;
	private Vector3 offset;
	
    // For dragging things around
    /*
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
        

        if (Input.GetMouseButtonDown(0)) {
                if (this.GetComponent<CircleCollider2D> ().IsTouching(player.GetComponent<CircleCollider2D>())) {
                    transform.SetParent(playerHand.transform);
                    transform.localPosition = new Vector3(0, 0, -1);
                    this.GetComponent<BunnyAI>().enabled = false;
                    player.GetComponent<Inventory>().addBunny(gameObject);
                    isBeingHeld = true;
            }
		}
        if (Input.GetMouseButtonDown(1)) {
            if (isBeingHeld) {
                transform.parent = null;
                this.GetComponent<BunnyAI>().enabled = true;
                player.GetComponent<Inventory>().removeBunny(this.GetComponent<BunnyAI>().breed + "-" + this.GetComponent<BunnyAI>().gender);
                isBeingHeld = false;
            } 
        }
    }
}
