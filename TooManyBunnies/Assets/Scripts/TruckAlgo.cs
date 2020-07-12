using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TruckAlgo : MonoBehaviour
{
    public float progressionMultiplier = 1f;
    public int resetSeconds = 60;
    private float currentVisitNumber = 1f;
    private float visitCooldownTime = 10;
    private Dictionary<int, string> rarityDictionary = createBunnyRarityMap();

    void Update()
    {
        visitCooldown();
        if (visitCooldownTime <= 0) {
            visit();
        }
    }

    // Cooldown time between truck visits
    private void visitCooldown() {
        visitCooldownTime -= Time.deltaTime;
    }

    private void visit() {
        string[] bunnies = {getWantedBunny(), getWantedBunny(), getWantedBunny()};
        currentVisitNumber++;
    }

    private string getWantedBunny() {
        float randomSeed = UnityEngine.Random.Range(0f, 1f);
        int bunnyNum = (int)(Math.Ceiling(randomSeed * progressionMultiplier * currentVisitNumber));
        if (bunnyNum > 20) {
            bunnyNum = 20;
        }
        //print("bunnyNum: " + bunnyNum);
        //print("This one sells for more: " + rarityDictionary[bunnyNum]);
        return rarityDictionary[bunnyNum];
    }

    private static Dictionary<int, string> createBunnyRarityMap() {
        Dictionary<int, string> bunnyRarity = new Dictionary<int, string>();
        bunnyRarity.Add(1, "White");
        bunnyRarity.Add(2, "Black");
        bunnyRarity.Add(3, "Gray");
        bunnyRarity.Add(4, "Red");
        bunnyRarity.Add(5, "Blue");
        bunnyRarity.Add(6, "Yellow");
        bunnyRarity.Add(7, "Pink");
        bunnyRarity.Add(8, "Purple");
        bunnyRarity.Add(9, "Green");
        bunnyRarity.Add(10, "Cyan");
        bunnyRarity.Add(11, "Orange");
        bunnyRarity.Add(12, "Brown");
        bunnyRarity.Add(13, "Silver");
        bunnyRarity.Add(14, "Metal");
        bunnyRarity.Add(15, "Rose Qaurtz");
        bunnyRarity.Add(16, "Amethyst");
        bunnyRarity.Add(17, "Emerald");
        bunnyRarity.Add(18, "Tourmaline");
        bunnyRarity.Add(19, "Adventurine");
        bunnyRarity.Add(20, "Golden");
        return bunnyRarity;
    }
}
