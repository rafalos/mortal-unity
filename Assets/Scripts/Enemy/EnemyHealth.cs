using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour {

    EnemyHealthBar enemyHealthBar;
    [SerializeField] TextMeshPro damageText;
    [SerializeField] float maxHealthPoints = 100;
    float currentHealthPoints = 100;
    [SerializeField] BloodGlobe bloodGlobe;

    private void Start() {
        enemyHealthBar = FindObjectOfType<EnemyHealthBar>();
    }
    private void Update() {
        if(currentHealthPoints <= 0) {
            HandleDeath();
        }
    }

    private void OnMouseEnter() {
        FindObjectOfType<PlayerBase>().SetTarget(gameObject);
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseExit() {
        FindObjectOfType<PlayerBase>().clearTarget();
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    // called by animation event
    public void DealDamage(float damage) {
        currentHealthPoints -= damage;
        if (currentHealthPoints <= 0) {
            HandleDeath();
            return;
        } else {
            var damageNewText = Instantiate(damageText, transform.position, Quaternion.identity);
            damageNewText.text = damage.ToString();
            Destroy(damageNewText.gameObject, 0.5f);
            enemyHealthBar.UpdateBar();
        }
    }

    private void HandleDeath() {
        DropItems();
        Destroy(gameObject);
    }

    private void DropItems() {
        float random = Utils.GetRandomIntInRange(3,6);
        for (int i = 0; i < random; i++) {
            var newPos = new Vector2(transform.position.x + Utils.GetRandomFloatInRange(0.1f, 1.9f), transform.position.y + Utils.GetRandomFloatInRange(0.1f, 1.9f));
            Instantiate(bloodGlobe, newPos, Quaternion.identity);
        }  
    }

    public float GetCurrentHealth() {
        return currentHealthPoints;
    }

}
