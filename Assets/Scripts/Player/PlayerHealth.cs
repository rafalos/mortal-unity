using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealthPoints = 40f;
    [SerializeField] float maximumHealthPoints = 200f;
    [SerializeField] Text healthUiText;
    [SerializeField] GameObject healthBar;
    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI() {
        healthUiText.text = ReturnHealthInPercent().ToString() + " %"; ;
        UpdateHealthbarHeight();
    }

    private void UpdateHealthbarHeight() {
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(100, ReturnHealthInPercent());
    }

    private float ReturnHealthInPercent() {
        return (currentHealthPoints / maximumHealthPoints) * 100;
    }

    public void HealPlayer(float healthPointsAmount) {
        if(currentHealthPoints + healthPointsAmount >= maximumHealthPoints) {
            currentHealthPoints = maximumHealthPoints;
        } else {
            currentHealthPoints += healthPointsAmount;
        }
        UpdateUI();
    }
}
