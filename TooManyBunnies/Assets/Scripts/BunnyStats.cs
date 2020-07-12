using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
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
    public static int gold;
    public static int completedTasks;
    public static bool goldBunnySold;

    // Start is called before the first frame update
    void Start()
    {
        bunnyCount = 0;
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
        gold = 0;
        completedTasks = 0;

}

    // Update is called once per frame
    void Update()
    {
        if (bunnyCount >= 10000)
        {
            UIManager.LossCondition = true;
        }

        if (goldBunnySold)
        {
            UIManager.WinCondition = true;
        }

    }

    // Getters
    public int getAdventurineBunnyCount()
    {
        return adventurineBunnyCount;
    }

    public int getAmethystBunnyCount()
    {
        return amethystBunnyCount;
    }

    public int getBlackBunnyCount()
    {
        return blackBunnyCount;
    }

    public int getBlueBunnyCount()
    {
        return blueBunnyCount;
    }

    public int getBrownBunnyCount()
    {
        return brownBunnyCount;
    }

    public int getBunnyCount()
    {
        return bunnyCount;
    }

    public int getCrystalBunnyCount()
    {
        return crystalBunnyCount;
    }

    public int getCyanBunnyCount()
    {
        return cyanBunnyCount;
    }

    public int getEmeraldBunnyCount()
    {
        return emeraldBunnyCount;
    }

    public int getGold()
    {
        return gold;
    }

    public int getGoldenBunnyCount()
    {
        return goldenBunnyCount;
    }

    public int getGreenBunnyCount()
    {
        return greenBunnyCount;
    }

    public int getGrayBunnyCount()
    {
        return grayBunnyCount;
    }

    public int getOrangeBunnyCount()
    {
        return orangeBunnyCount;
    }

    public int getPurpleBunnyCount()
    {
        return purpleBunnyCount;
    }

    public int getRedBunnyCount()
    {
        return redBunnyCount;
    }

    public int getRoseQuartzBunnyCount()
    {
        return roseQuartzBunnyCount;
    }

    public int getSilverBunnyCount()
    {
        return silverBunnyCount;
    }

    public int getTourmalineBunnyCount()
    {
        return tourmalineBunnyCount;
    }

    public int getWhiteBunnyCount()
    {
        return whiteBunnyCount;
    }

    public int getYellowBunnyCount()
    {
        return yellowBunnyCount;
    }

}
