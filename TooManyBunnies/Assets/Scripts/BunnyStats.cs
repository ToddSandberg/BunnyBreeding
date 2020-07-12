using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BunnyStats : MonoBehaviour
{

    public static int bunnyCount;
    public static int whiteBunnyCount;
    public static int blackBunnyCount;
    public static int grayBunnyCount;
    public static int redBunnyCount;
    public static int blueBunnyCount;
    public static int yellowBunnyCount;
    public static int brownBunnyCount;
    public static int purpleBunnyCount;
    public static int greenBunnyCount;
    public static int orangeBunnyCount;
    public static int crystalBunnyCount;
    public static int cyanBunnyCount;
    public static int goldenBunnyCount;
    public static int roseQuartzBunnyCount;
    public static int adventurineBunnyCount;
    public static int tourmalineBunnyCount;
    public static int silverBunnyCount;
    public static int emeraldBunnyCount;
    public static int amethystBunnyCount;
    public static int m_gold;
    public static int completedTasks;
    public static bool goldBunnySold;
    public static float progressionMultiplier;
    public static int penPrice;

    // Start is called before the first frame update
    void Start()
    {
        bunnyCount = GameObject.Find("Bunnies").transform.childCount;
        whiteBunnyCount = 0;
        blackBunnyCount = 0;
        grayBunnyCount = 0;
        redBunnyCount = 0;
        blueBunnyCount = 0;
        yellowBunnyCount = 0;
        brownBunnyCount = 0;
        purpleBunnyCount = 0;
        greenBunnyCount = 0;
        orangeBunnyCount = 0;
        crystalBunnyCount = 0;
        cyanBunnyCount = 0;
        goldenBunnyCount = 0;
        roseQuartzBunnyCount = 0;
        adventurineBunnyCount = 0;
        tourmalineBunnyCount = 0;
        silverBunnyCount = 0;
        emeraldBunnyCount = 0;
        amethystBunnyCount = 0;
        m_gold = 10;
        progressionMultiplier = 1f;
        penPrice = 10;
        completedTasks = 0;

}

    // Update is called once per frame
    void Update()
    {

        if (bunnyCount >= 800)
        {
            UIManager.LossCondition = true;
        }

        if (goldBunnySold)
        {
            UIManager.WinCondition = true;
        }

    }

    // Getters
    public static int getAdventurineBunnyCount()
    {
        return adventurineBunnyCount;
    }

    public static int getAmethystBunnyCount()
    {
        return amethystBunnyCount;
    }

    public static int getBlackBunnyCount()
    {
        return blackBunnyCount;
    }

    public static int getBlueBunnyCount()
    {
        return blueBunnyCount;
    }

    public static int getBrownBunnyCount()
    {
        return brownBunnyCount;
    }

    public static int getBunnyCount()
    {
        return bunnyCount;
    }

    public static int getCrystalBunnyCount()
    {
        return crystalBunnyCount;
    }

    public static int getCyanBunnyCount()
    {
        return cyanBunnyCount;
    }

    public static int getCompletedTask()
    {
        return completedTasks;
    }

    public static int getEmeraldBunnyCount()
    {
        return emeraldBunnyCount;
    }

    public static int getGold()
    {
        return m_gold;
    }

    public static void setGold(int gold) {
        m_gold = gold;
    }

    public static int getGoldenBunnyCount()
    {
        return goldenBunnyCount;
    }

    public static int getGreenBunnyCount()
    {
        return greenBunnyCount;
    }

    public static int getGrayBunnyCount()
    {
        return grayBunnyCount;
    }

    public static int getOrangeBunnyCount()
    {
        return orangeBunnyCount;
    }

    public static int getPurpleBunnyCount()
    {
        return purpleBunnyCount;
    }

    public static int getRedBunnyCount()
    {
        return redBunnyCount;
    }

    public static int getRoseQuartzBunnyCount()
    {
        return roseQuartzBunnyCount;
    }

    public static int getSilverBunnyCount()
    {
        return silverBunnyCount;
    }

    public static int getTourmalineBunnyCount()
    {
        return tourmalineBunnyCount;
    }

    public static int getWhiteBunnyCount()
    {
        return whiteBunnyCount;
    }

    public static int getYellowBunnyCount()
    {
        return yellowBunnyCount;
    }


    public static void addBunny(string color)
    {
        bunnyCount++;
    }

    
    public static void removeBunny(string color)
    {
        bunnyCount--;
    }

}
