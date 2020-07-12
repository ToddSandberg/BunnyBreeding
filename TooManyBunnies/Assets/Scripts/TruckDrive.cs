using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDrive : MonoBehaviour
{
    private bool driving = true;
    private int filled = 0;

    void Update() {
        if (driving) {
            if (gameObject.transform.position.x > -1 && gameObject.transform.position.x < 1) {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                driving = false;
                gameObject.transform.position += new Vector3(2f, 0, 0);
            } else if (gameObject.transform.position.x == 30) {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                driving = false;
                gameObject.transform.position = new Vector3(-20, 0, 0);
                gameObject.GetComponent<TruckAlgo>().stopVisiting();
            }
        } else if (filled > 20) {
            print("Filled");
            drive();
        } else {
            filled++;
        }
    }

    public void drive() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);  
        driving = true;  
        filled = 0;    
    }
}
