using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyCount;

    private void OnTriggerEnter2D(Collider2D collision) {
        for (int i = 0; i < enemyCount; i++) {
            Instantiate(enemy, transform.position + Random.insideUnitSphere * 3, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
