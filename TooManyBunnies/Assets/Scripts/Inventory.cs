using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> bunnies = new Dictionary<string, int>();

    public void addBunny(GameObject bunny) {
        string key = "temp";
        if (bunnies.ContainsKey(key)) {
            bunnies[key]++;
        } else {
            bunnies.Add(key, 1);
        }
    }

    public void removeBunny(string bunnyId) {
        if (!bunnies.ContainsKey(bunnyId)) {
            throw new System.ArgumentException("Inventory map does not contain bunnyId", bunnyId);
        }

        bunnies[bunnyId]--;
        if (bunnies[bunnyId] <= 0) {
            bunnies.Remove(bunnyId);
        }
    }

    public Dictionary<string, int> getBunnies() {
        return bunnies;
    }
}
