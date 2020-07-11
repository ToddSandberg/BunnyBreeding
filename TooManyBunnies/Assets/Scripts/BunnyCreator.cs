using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCreator : MonoBehaviour
{

    public GameObject whiteBunny;


    Dictionary<(string, string), string> breedingMap;
    GameObject bunnyStorage;

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
            Debug.Log("Same genders can't breed, silly!");
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
            string result = "";
            if (breedingMap.ContainsKey((breedOne, breedTwo)))
            {
                result = breedingMap[(breedOne, breedTwo)];
            }
            else if (breedingMap.ContainsKey((breedTwo, breedOne)))
            {
                result = breedingMap[(breedTwo, breedOne)];
            }
            int randomChoice;
            if (result != "")
            {
                randomChoice = Random.Range(1, 3);
            }
            else
            {
                randomChoice = Random.Range(1, 2);
            }
            if (randomChoice == 3)
            {
                GameObject bunbun = Instantiate(whiteBunny, new Vector3(posX, posY, 0), Quaternion.identity);
                bunbun.GetComponent<BunnyAI>().breed = result;
            }
            if (randomChoice == 2)
            {
                GameObject bunbun = Instantiate(whiteBunny, new Vector3(posX, posY, 0), Quaternion.identity);
                bunbun.GetComponent<BunnyAI>().breed = breedTwo;
            }
            if (randomChoice == 1)
            {
                GameObject bunbun = Instantiate(whiteBunny, new Vector3(posX, posY, 0), Quaternion.identity);
                bunbun.GetComponent<BunnyAI>().breed = breedOne;
            }
            return 10;  //TODO CHANGE THIS TO USE PUBLIC VARIABLE
        }




    }
}
