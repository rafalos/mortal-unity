using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpell : MonoBehaviour
{
    float timeDuration = 5f;
    int buffAmount = 3;
    float manaCost = 10f;
    PlayerStatistics playerStatistics;
    PlayerMana playerMana;

    private void Start() {
        playerStatistics = FindObjectOfType<PlayerStatistics>();
        playerMana = FindObjectOfType<PlayerMana>();
        playerMana.SpendMana(manaCost);
        StartCoroutine(HandleAuraCast());
    }

    IEnumerator HandleAuraCast() {
        playerStatistics.speed.IncreaseStat(buffAmount);
        yield return new WaitForSeconds(timeDuration);
        playerStatistics.speed.DecraseStat(buffAmount);
        Destroy(gameObject);
    }
}
