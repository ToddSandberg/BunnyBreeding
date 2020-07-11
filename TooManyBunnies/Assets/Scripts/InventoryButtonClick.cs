using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonClick : MonoBehaviour
{

    public GameObject playerHand;
    public GameObject bunnyBreeder;

    private Button myButton = null;

    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(bunnyBreeder.GetComponent<BunnyCreator>().createBunny(GameObject whiteBunny, string resultBreed, float posX, float posY, string gender));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
