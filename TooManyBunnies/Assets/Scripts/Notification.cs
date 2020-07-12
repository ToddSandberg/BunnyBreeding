using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public float showTime = 10;

    private float halfway;

    void Start() {
        halfway = showTime/2;
    }

    // Update is called once per frame
    void Update()
    {
        notificationCooldown();
        GetComponent<CanvasGroup>().alpha = getAlpha();
        if (showTime <= 0) {
            Destroy(gameObject);
        }
    }

    private void notificationCooldown() {
        showTime -= Time.deltaTime;
    }

    private float getAlpha() {
        return Math.Abs((halfway - Math.Abs(showTime - halfway)) * (1f/halfway));
    }
}
