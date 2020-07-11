using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonClick : MonoBehaviour
{

    public GameObject player;
    public GameObject bunnyBreeder;

    private Button myButton;

    void Start()
    {
        player = GameObject.Find("Player");
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(handleClick);
    }

    void handleClick() {
        string id = gameObject.GetComponentInChildren<Text>().text.Split('•')[0].Trim();
        GameObject bunny = player.GetComponent<Inventory>().removeBunny(id);
        bunny.SetActive(true);
        bunny.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}
