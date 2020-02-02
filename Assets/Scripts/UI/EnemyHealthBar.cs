using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    GameObject currentTarget;
    PlayerBase playerBase;
    [SerializeField] GameObject interfaceElements;
    [SerializeField] Text enemyNameText;
    [SerializeField] Text enemyHealthAmountText;
    [SerializeField] Image enemyGraphicBar;


    private void Start() {
        playerBase = FindObjectOfType<PlayerBase>();
    }

    void Update() {
        currentTarget = playerBase.GetCurrentTarget();
        if (currentTarget) {
            UpdateBar();
            interfaceElements.SetActive(true);
            enemyNameText.text = currentTarget.name;
        } else {
            interfaceElements.SetActive(false);
        }
    }

    public void UpdateBar() {
        if(currentTarget) {
            float health = currentTarget.GetComponent<EnemyHealth>().GetCurrentHealth();
            enemyHealthAmountText.text = health.ToString();
            enemyGraphicBar.rectTransform.sizeDelta = new Vector2(health, 100);
        } else {
            return;
        }
        
    }
}
