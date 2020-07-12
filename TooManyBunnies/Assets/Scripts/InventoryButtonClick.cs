using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryButtonClick : MonoBehaviour, IPointerClickHandler
{

    public GameObject player;
    public GameObject bunnyBreeder;

    private Button myButton;

    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) {
            removeBunnyFromInventory();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle) {
        }
        else if (eventData.button == PointerEventData.InputButton.Right) {
            int loopLength = 0;
            Int32.TryParse(gameObject.GetComponentInChildren<Text>().text.Split('•')[1], out loopLength);
            for(int i=0; i<loopLength; i++) {
                removeBunnyFromInventory();
            }
        }
    }

    public void removeBunnyFromInventory() {
            string id = gameObject.GetComponentInChildren<Text>().text.Split('•')[0].Trim();
            GameObject bunny = player.GetComponent<Inventory>().removeBunny(id);
            bunny.SetActive(true);
            bunny.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + player.GetComponent<CircleCollider2D>().offset.y - (2 * player.GetComponent<CircleCollider2D>().radius), 0);
    }

}
