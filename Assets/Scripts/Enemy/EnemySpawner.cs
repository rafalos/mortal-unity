using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyCount;

    private void OnTriggerEnter2D(Collider2D collision) {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
