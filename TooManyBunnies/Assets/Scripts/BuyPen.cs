using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyPen : MonoBehaviour
{

    public Transform pen;

    GameObject player;
    Transform penList;
    Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        penList = GameObject.Find("Pens").transform;
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(purchasePen);
    }


    private void purchasePen()
    {
        if (BunnyStats.m_gold >= BunnyStats.penPrice)
        {
            BunnyStats.m_gold -= BunnyStats.penPrice;
            BunnyStats.penPrice = (int)(BunnyStats.penPrice * 1.5 * BunnyStats.progressionMultiplier);
            gameObject.GetComponentInChildren<Text>().text = "Buy a pen: " + BunnyStats.penPrice;
            createPen();
        }
    }


    private void createPen()
    {
        Transform purchase = Instantiate(pen, penList);

        purchase.position = player.transform.position + new Vector3(3,-1,0);

    }
}
