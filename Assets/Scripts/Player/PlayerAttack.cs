using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] GameObject hitParticle;
    private Animator playerAnimator;
    PlayerStatus playerStatus;
    GameObject currentTarget;

    private void Start() {
        playerAnimator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatus>();
    }
    public void StartAttacking(GameObject target) {
        if(!target) {
            playerAnimator.SetBool("isAttacking", false);
            return;
        }
        currentTarget = target;
        playerAnimator.SetFloat("Horizontal", CalculateTargetDistance(currentTarget).x);
        playerAnimator.SetFloat("Vertical", CalculateTargetDistance(currentTarget).y);
        playerAnimator.SetBool("isWalking", false);
        playerAnimator.SetBool("isAttacking", true);
    }

    public void DealDamageToTarget() {
        var damage = Utils.GetRandomIntInRange(playerStatus.GetPlayerMinimumDamage(), playerStatus.GetPlayerMaximumDamage());
        currentTarget.GetComponent<EnemyHealth>().DealDamage(damage);
        var particleObject = Instantiate(hitParticle, currentTarget.transform.position, Quaternion.identity);
        Destroy(particleObject, 0.5f);
    }
    private Vector3 CalculateTargetDistance(GameObject target) {
        return target.transform.position - transform.position;
    }
}
