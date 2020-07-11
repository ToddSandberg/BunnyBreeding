using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> bunnies = Dictionary<string, int>();

    public addBunny(GameObject bunny) {
        string key = "temp";
        if (bunnies.ContainsKey(key)) {
            bunnies[key]++;
        } else {
            bunnies.Add(key, 1);
        }
    }

    public removeBunny(string bunnyId) {
        if (!bunnies.ContainsKey(key)) {
            throw new System.ArgumentException("Inventory map does not contain bunnyId", bunnyId);
        }

        bunnies[bunnyId]--;
        if (bunnies[bunnyId] <= 0) {
            bunnies.Remove(bunnyId);
        }
    }

    public getBunnies() {
        return bunnies;
    }
}
