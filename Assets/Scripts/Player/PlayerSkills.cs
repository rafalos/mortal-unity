using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {
    PlayerMana playerMana;
    PlayerBase playerBase;
    NotificationText notificationText;
    Camera mainCamera;
    [SerializeField] AreaSpell areaSpell;
    [SerializeField] Projectile arrow;
    [SerializeField] Projectile basicMissle;
    [SerializeField] AuraSpell auraSpell;

    private void Start() {
        playerBase = GetComponent<PlayerBase>();
        mainCamera = Camera.main;
        playerMana = GetComponent<PlayerMana>();
        notificationText = FindObjectOfType<NotificationText>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Vector2 worldDistance = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (playerMana.GetCurrentPlayerMana() >= areaSpell.GetManaCost()) {
                Instantiate(areaSpell, worldDistance, Quaternion.identity);
            }
            else {
                notificationText.DisplayText("Not enough mana");
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (playerBase.GetCurrentTarget()) {
                Instantiate(arrow, transform.position, Quaternion.identity);
            }
            else {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (playerBase.GetCurrentTarget()) {
                Instantiate(basicMissle, transform.position, Quaternion.identity);
            }
            else {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (FindObjectOfType<AuraSpell>()) {
                return;
            }
            else {
                Instantiate(auraSpell, transform.position, Quaternion.identity);
            }
            
        }
    }
}