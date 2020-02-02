using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerStatistics playerStatistics;
    private Camera mainCamera;
    private Animator playerAnimator;

    void Start() {
        playerStatistics = GetComponent<PlayerStatistics>();
        playerAnimator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    public void MovePlayer() {
        playerAnimator.SetBool("isWalking", true);
        playerAnimator.SetBool("isAttacking", false);
        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        FaceTarget(targetPosition);
        playerAnimator.SetFloat("Horizontal", CalculateDistanceToMove(targetPosition).x);
        playerAnimator.SetFloat("Vertical", CalculateDistanceToMove(targetPosition).y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, (playerStatistics.GetPlayerMovementSpeed() * Time.deltaTime));
    }

    private Vector3 CalculateDistanceToMove(Vector3 worldDistance) {
        return worldDistance - transform.position;
    }

    private void FaceTarget(Vector3 target) {
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
   
