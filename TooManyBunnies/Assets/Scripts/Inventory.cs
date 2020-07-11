using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> bunnies = new Dictionary<string, int>();

    public GameObject inventoryUIHandler;

    public void addBunny(GameObject bunny) {
        BunnyAI bunnyAiScript = bunny.GetComponent<BunnyAI>();
        string key = bunnyAiScript.breed + "-" + bunnyAiScript.gender;
        if (bunnies.ContainsKey(key)) {
            bunnies[key]++;
        } else {
            bunnies.Add(key, 1);
        }

        inventoryUIHandler.GetComponent<InventoryUIHandler>().refresh(bunnies);

        //DEBUG while there is no UI to show
        print("added bunny");
        printDictionary();
    }

    public void removeBunny(string bunnyId) {
        if (!bunnies.ContainsKey(bunnyId)) {
            throw new System.ArgumentException("Inventory map does not contain bunnyId", bunnyId);
        }

        bunnies[bunnyId]--;
        if (bunnies[bunnyId] <= 0) {
            bunnies.Remove(bunnyId);
        }

        inventoryUIHandler.GetComponent<InventoryUIHandler>().refresh(bunnies);

        //DEBUG while there is no UI to show
        print("removed bunny");
        printDictionary();
    }

    public Dictionary<string, int> getBunnies() {
        return bunnies;
    }

    private void printDictionary() {
        foreach(var item in bunnies)
        {
            print(item.Key + " : " + item.Value);
        }
    }
}
