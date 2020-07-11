using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> bunnies = new Dictionary<string, int>();
    private Dictionary<string, Stack<GameObject>> bunnyGameObjects = new Dictionary<string, Stack<GameObject>>();

    public GameObject inventoryUIHandler;

    public void addBunny(GameObject bunny) {
        BunnyAI bunnyAiScript = bunny.GetComponent<BunnyAI>();
        string key = bunnyAiScript.breed + "-" + bunnyAiScript.gender;
        if (bunnies.ContainsKey(key)) {
            bunnies[key]++;
            Stack<GameObject> bunnyStack = bunnyGameObjects[key];
            bunnyStack.Push(bunny);
            bunnyGameObjects[key] = bunnyStack;
        } else {
            bunnies.Add(key, 1);
            Stack<GameObject> bunnyStack = new Stack<GameObject>();
            bunnyStack.Push(bunny);
            bunnyGameObjects.Add(key, bunnyStack);
        }

        inventoryUIHandler.GetComponent<InventoryUIHandler>().refresh(bunnies);

        //DEBUG while there is no UI to show
        print("added bunny");
        printDictionary();
    }

    public GameObject removeBunny(string bunnyId) {
        if (!bunnies.ContainsKey(bunnyId)) {
            throw new System.ArgumentException("Inventory map does not contain bunnyId", bunnyId);
        }

        bunnies[bunnyId]--;
        GameObject bunnyGameObject = bunnyGameObjects[bunnyId].Pop();

        if (bunnies[bunnyId] <= 0) {
            bunnies.Remove(bunnyId);
            bunnyGameObjects.Remove(bunnyId);
        }

        inventoryUIHandler.GetComponent<InventoryUIHandler>().refresh(bunnies);

        //DEBUG while there is no UI to show
        print("removed bunny");
        printDictionary();

        return bunnyGameObject;
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
