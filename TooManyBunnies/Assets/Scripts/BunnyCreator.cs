using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCreator : MonoBehaviour
{

    public GameObject whiteBunny;
    public GameObject playerHand;


    private Dictionary<(string, string), string> breedingMap;
    private Dictionary<string, int> breedingTimes = new Dictionary<string, int>();
    private GameObject bunnyStorage;

    void Start()
    {
        bunnyStorage = GameObject.Find("Bunnies");
        breedingMap = new Dictionary<(string, string), string>();
        breedingMap.Add(("White", "Black"), "Gray");
        breedingMap.Add(("White", "Red"), "Pink");
        breedingMap.Add(("White", "Blue"), "Cyan");
        breedingMap.Add(("Red", "Yellow"), "Orange");
        breedingMap.Add(("Red", "Blue"), "Purple");
        breedingMap.Add(("Blue", "Yellow"), "Green");
        breedingMap.Add(("Orange", "Black"), "Brown");
        breedingMap.Add(("Gray", "Brown"), "Metal");
        breedingMap.Add(("Pink", "Metal"), "Rose Quartz");
        breedingMap.Add(("Purple", "Metal"), "Amethyst");
        breedingMap.Add(("Metal", "Green"), "Emerald");
        breedingMap.Add(("Metal", "Cyan"), "Silver");
        breedingMap.Add(("Rose Quartz", "Amethyst"), "Tourmaline");
        breedingMap.Add(("Emerald", "Silver"), "Adventurine");
        breedingMap.Add(("Tourmaline", "Adventure"), "Golden");

        breedingTimes.Add("White", 2);
        breedingTimes.Add("Gray", 2);
        breedingTimes.Add("Pink", 2);
        breedingTimes.Add("Black", 2);
        breedingTimes.Add("Cyan", 2);
        breedingTimes.Add("Orange", 2);
        breedingTimes.Add("Purple", 2);
        breedingTimes.Add("Green", 2);
        breedingTimes.Add("Brown", 2);
        breedingTimes.Add("Metal", 2);
        breedingTimes.Add("Rose Quartz", 2);
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



    public int breedBunny(GameObject bunnyOne, GameObject bunnyTwo)
    {
        if (bunnyTwo.gameObject.tag != "Bunny")
        {
            return 0;
        }

        BunnyAI bunnyOneAI = bunnyOne.GetComponent<BunnyAI>();
        BunnyAI bunnyTwoAI = bunnyTwo.GetComponent<BunnyAI>();
        string genderOne = bunnyOneAI.gender;
        string genderTwo = bunnyTwoAI.gender;

        if (genderOne == genderTwo)
        {
            //Debug.Log("Same genders can't breed, silly!");
        }
        else
        {

            Transform bunnyOneTransform = bunnyOne.transform;
            Transform bunnyTwoTransform = bunnyTwo.transform;
            float posX = (bunnyOneTransform.position.x + bunnyTwoTransform.position.x) / 2;
            float posY = (bunnyOneTransform.position.y + bunnyTwoTransform.position.y) / 2;

            string breedOne = bunnyOneAI.breed;
            string breedTwo = bunnyTwoAI.breed;

            Debug.Log("Creating bunny at " + posX + ", " + posY + ".");
            Debug.Log("With Parents " + breedOne + ", " + breedTwo + ".");
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
                randomChoice = Random.Range(1, 4);
            }
            else
            {
                randomChoice = Random.Range(1, 3);
            }

            int randomGender = Random.Range(1, 3);
            string gender = "Male";
            if (randomGender == 1) {
                gender = "Female";
            }

            if (randomChoice == 3)
            {
                createBunny(whiteBunny, resultBreed, posX, posY, gender);
            }
            if (randomChoice == 2)
            {
                createBunny(whiteBunny, breedTwo, posX, posY, gender);
            }
            if (randomChoice == 1)
            {
                createBunny(whiteBunny, breedOne, posX, posY, gender);
            }
            return 10;  //TODO CHANGE THIS TO USE PUBLIC VARIABLE
        }



        return 0;
    }

    private void createBunny(GameObject whiteBunny, string resultBreed, float posX, float posY, string gender) {
        GameObject bunbun = Instantiate(whiteBunny, new Vector3(posX, posY, 0), Quaternion.identity);
        bunbun.transform.SetParent(bunnyStorage.transform);
        bunbun.GetComponent<BunnyAI>().gender = gender;
        bunbun.GetComponent<BunnyAI>().breed = resultBreed;
        bunbun.GetComponent<BunnyAI>().breedTimer = breedingTimes[resultBreed];
        bunbun.GetComponent<BunnyPickup>().playerHand = playerHand;
    }
}
