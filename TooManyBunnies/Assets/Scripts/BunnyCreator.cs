using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCreator : MonoBehaviour
{

     Dictionary<(string, string), string> breedingMap;

    void Start()
    {
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



    void breedBunny(float xPos, float yPos, string parentOne, string ParentTwo)
    {

    }
}
