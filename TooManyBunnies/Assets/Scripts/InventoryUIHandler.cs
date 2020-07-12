using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject textBox;
    private Image myImage;
    

    public void refresh(Dictionary<string, int> bunnies)
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach(var item in bunnies)
        {
            createTextBox(item.Key, item.Value);
        }
    }

    private void createTextBox(string name, int amount) {
        GameObject thisTextBox = Instantiate(textBox);
        thisTextBox.GetComponent<InventoryButtonClick>().player = player;
        thisTextBox.transform.SetParent(gameObject.transform);
        thisTextBox.GetComponentInChildren<Text>().text = name + " • " + amount;

        myImage = thisTextBox.transform.GetChild(1).gameObject.GetComponent<Image>();

        string type = thisTextBox.GetComponentInChildren<Text>().text.Split('-')[0].Trim();

        myImage.sprite = Resources.Load<Sprite>("Sprites/" + type.ToLower() + "_bunny_1");
        
        // Debug.Log("Sprites/" + type.ToLower() + "_bunny_1");
        // Debug.Log(name);
    }
}
