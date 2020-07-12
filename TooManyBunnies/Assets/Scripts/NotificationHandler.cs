using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    public GameObject notification;
    public void createNotification(string text, Vector3 worldPosition) {
        GameObject notif = Instantiate(notification);
        notif.GetComponentsInChildren<Text>()[0].text = text;
        notif.transform.SetParent(gameObject.transform);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        notif.GetComponent<RectTransform>().anchoredPosition = new Vector3(screenPos.x - 100, screenPos.y + 50, 0);
    }
}
