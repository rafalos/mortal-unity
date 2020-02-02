using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpell : MonoBehaviour {
    public List<GameObject> enemies;
    [SerializeField] float manaCost = 10f;
    [SerializeField] float range = 7f;
    [SerializeField] float damage = 20f;

    private void Start() {
        FindObjectOfType<PlayerMana>().SpendMana(manaCost);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        enemies.Add(collision.gameObject);
    }

    public void EndCast()
    {
        Destroy(gameObject);
    }

    public void DealDamage() {
        for (int i = 0; i < enemies.Count; i++) {
            enemies[i].GetComponent<EnemyHealth>().DealDamage(damage);
        }
    }

    public float GetManaCost() {
        return manaCost;
    }

    public float GetRange() {
        return range;
    }
}

