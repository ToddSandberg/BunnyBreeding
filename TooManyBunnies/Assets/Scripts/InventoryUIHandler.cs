using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject textBox;

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
        thisTextBox.transform.SetParent(gameObject.transform);

        thisTextBox.GetComponentInChildren<Text>().text = name + " • " + amount;
    }
}
