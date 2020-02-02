using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {
    [SerializeField] float currentManaPoints = 40f;
    [SerializeField] float maximumManaPoints = 100f;
    [SerializeField] Text manaUiText;
    [SerializeField] GameObject manaBar;
    void Start() {
        UpdateManaUI();
    }

    private void UpdateManaUI() {
        manaUiText.text = ReturnManaInPercent().ToString() + " %"; ;
        UpdateManabarHeight();
    }

    private void UpdateManabarHeight() {
        manaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(100, ReturnManaInPercent());
    }

    private float ReturnManaInPercent() {
        return (currentManaPoints / maximumManaPoints) * 100;
    }

    public void SpendMana(float amount) {
        currentManaPoints -= amount;
        UpdateManaUI();
    }

    public float GetCurrentPlayerMana() {
        return currentManaPoints;
    }
}
