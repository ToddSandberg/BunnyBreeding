using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BunnyCreator : MonoBehaviour
{

    [Serializable]
    public struct BunnySprite {
        public string id;
        public GameObject bunny;
    }

    public GameObject whiteBunny;
    public GameObject playerHand;
    public BunnySprite[] spriteMap;

    private Dictionary<(string, string), string> breedingMap;
    private Dictionary<string, int> breedingTimes = new Dictionary<string, int>();
    private GameObject bunnyStorage;

    void Start()
    {

        bunnyStorage = GameObject.Find("Bunnies");
        breedingMap = new Dictionary<(string, string), string>();
        breedingMap.Add(("White",       "Black"),       "Gray");
        breedingMap.Add(("White",       "Red"),         "Pink");
        breedingMap.Add(("White",       "Blue"),        "Cyan");
        breedingMap.Add(("Red",         "Yellow"),      "Orange");
        breedingMap.Add(("Red",         "Blue"),        "Purple");
        breedingMap.Add(("Blue",        "Yellow"),      "Green");
        breedingMap.Add(("Orange",      "Black"),       "Brown");
        breedingMap.Add(("Gray",        "Brown"),       "Crystal");
        breedingMap.Add(("Pink",        "Crystal"),     "Rose_Quartz");
        breedingMap.Add(("Purple",      "Crystal"),     "Amethyst");
        breedingMap.Add(("Crystal",     "Green"),       "Emerald");
        breedingMap.Add(("Crystal",     "Cyan"),        "Silver");
        breedingMap.Add(("Rose_Quartz", "Amethyst"),    "Tourmaline");
        breedingMap.Add(("Emerald",     "Silver"),      "Adventurine");
        breedingMap.Add(("Tourmaline",  "Adventurine"), "Golden");

        breedingTimes.Add("White", 2);
        breedingTimes.Add("Gray", 2);
        breedingTimes.Add("Pink", 2);
        breedingTimes.Add("Black", 2);
        breedingTimes.Add("Cyan", 2);
        breedingTimes.Add("Orange", 2);
        breedingTimes.Add("Purple", 2);
        breedingTimes.Add("Green", 2);
        breedingTimes.Add("Brown", 2);
        breedingTimes.Add("Crystal", 2);
        breedingTimes.Add("Rose_Quartz", 2);
        breedingTimes.Add("Amethyst", 2);
        breedingTimes.Add("Emerald", 2);
        breedingTimes.Add("Silver", 2);
        breedingTimes.Add("Tourmaline", 2);
        breedingTimes.Add("Adventurine", 2);
        breedingTimes.Add("Golden", 2);
        breedingTimes.Add("Red", 2);
        breedingTimes.Add("Blue", 2);
        breedingTimes.Add("Yellow", 2);
    }



    public float breedBunny(GameObject bunnyOne, GameObject bunnyTwo)
    {
        BunnyAI bunnyOneAI = bunnyOne.GetComponent<BunnyAI>();
        BunnyAI bunnyTwoAI = bunnyTwo.GetComponent<BunnyAI>();
        string genderOne = bunnyOneAI.gender;
        string genderTwo = bunnyTwoAI.gender;

        if (genderOne != genderTwo && genderOne == "Female")
        {
            playerHand = bunnyOne.GetComponent<BunnyPickup>().playerHand;
            Transform bunnyOneTransform = bunnyOne.transform;
            Transform bunnyTwoTransform = bunnyTwo.transform;
            float posX = (bunnyOneTransform.position.x + bunnyTwoTransform.position.x) / 2;
            float posY = (bunnyOneTransform.position.y + bunnyTwoTransform.position.y) / 2;

            string breedOne = bunnyOneAI.breed;
            string breedTwo = bunnyTwoAI.breed;

            // Debug.Log("Creating bunny at " + posX + ", " + posY + ".");
            // Debug.Log("With Parents " + breedOne + ", " + breedTwo + ".");
            string resultBreed = "";
            if (breedingMap.ContainsKey((breedOne, breedTwo)))
            {
                resultBreed = breedingMap[(breedOne, breedTwo)];
            }
            else if (breedingMap.ContainsKey((breedTwo, breedOne)))
            {
                resultBreed = breedingMap[(breedTwo, breedOne)];
            }
            int randomChoice;
            if (resultBreed != "")
            {
                randomChoice = UnityEngine.Random.Range(1, 4);
            }
            else
            {
                randomChoice = UnityEngine.Random.Range(1, 3);
            }

            int randomGender = UnityEngine.Random.Range(1, 3);
            string gender = "Male";
            if (randomGender == 1) {
                gender = "Female";
            }

            if (randomChoice == 3)
            {
                createBunny(resultBreed, posX, posY, gender);
            }
            if (randomChoice == 2)
            {
                createBunny(breedTwo, posX, posY, gender);
            }
            if (randomChoice == 1)
            {
                createBunny(breedOne, posX, posY, gender);
            }
            return bunnyOneAI.breedTimer;  //TODO CHANGE THIS TO USE PUBLIC VARIABLE
        }
        return 0;


    }

    private void createBunny(string resultBreed, float posX, float posY, string gender) {

        GameObject bunnyBaby = Instantiate(Resources.Load(resultBreed) as GameObject,
            new Vector3(posX, posY, 0),
            Quaternion.identity);

        BunnyStats.addBunny(resultBreed);
        bunnyBaby.transform.SetParent(bunnyStorage.transform);
        bunnyBaby.GetComponent<BunnyAI>().gender = gender;
        bunnyBaby.GetComponent<BunnyAI>().breed = resultBreed;
        bunnyBaby.GetComponent<BunnyAI>().breedTimer = breedingTimes[resultBreed];
        bunnyBaby.GetComponent<BunnyPickup>().playerHand = playerHand;
        bunnyBaby.GetComponent<AudioSource>().Play();
    }
}
