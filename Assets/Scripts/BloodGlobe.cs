using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodGlobe : MonoBehaviour {
    [SerializeField] float healthAmount = 30f;
    Vector3 playerPosition;
    PlayerHealth playerHealth;
    bool triggered = false;

    private void Start() {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void Update() {
        playerPosition = FindObjectOfType<PlayerMovement>().transform.position;
        if (triggered) {
            StartCoroutine(GatherBloodGlobe());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        triggered = true;
    }
    IEnumerator GatherBloodGlobe() {
        yield return transform.position = Vector2.MoveTowards(transform.position, playerPosition, 5f * Time.deltaTime);
        playerHealth.HealPlayer(healthAmount);
        if(transform.position == playerPosition ) {
            Destroy(gameObject);
        }   
    }
}
