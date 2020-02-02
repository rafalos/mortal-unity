using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {
    PlayerSkills playerSkills;
    PlayerHealth playerHealth;
    PlayerMana playerMana;
    PlayerMovement playerMovement;
    PlayerEquipment playerEquipment;
    Animator playerAnimator;
    PlayerAttack playerAttack;
    GameObject currentTarget;

    void Start() {
        playerSkills = GetComponent<PlayerSkills>();
        playerAttack = GetComponent<PlayerAttack>();
        playerEquipment = GetComponent<PlayerEquipment>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMana = GetComponent<PlayerMana>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if(currentTarget && IsTargetInRange()) {
                playerAttack.StartAttacking(currentTarget);
            } else {
                playerMovement.MovePlayer();
            }
        }
        else {
            EnterIdleMode();
        }
    }

    public void SetTarget(GameObject target) {
        currentTarget = target;
    }
    public void clearTarget() {
        currentTarget = null;
    }
    public GameObject GetCurrentTarget() {
        return currentTarget;
    }

    private bool IsTargetInRange() {
        var distance = Vector2.Distance(currentTarget.transform.position, transform.position);
        return distance <= playerEquipment.GetWeaponRange();
    }

    private void EnterIdleMode() {
        playerAnimator.SetBool("isAttacking", false);
        playerAnimator.SetBool("isWalking", false);
    }

   
}
