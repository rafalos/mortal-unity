using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText : MonoBehaviour
{
    bool displaying = false;
    [SerializeField] GameObject interfaceObjects;
    [SerializeField] Text notificationText;
    public void DisplayText(string text) {
        if(!displaying) {
            StartCoroutine(NotifyPlayer(text));
        } else {
            return;
        }
    }

    IEnumerator NotifyPlayer(string text) {
        displaying = true;
        interfaceObjects.SetActive(true);
        notificationText.text = text;
        yield return new WaitForSeconds(3f);
        interfaceObjects.SetActive(false);
        displaying = false;
    }
}
