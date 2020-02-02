using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileDamage = 10f;
    GameObject target;

    void Start()
    {
        target = FindObjectOfType<PlayerBase>().GetCurrentTarget();
        
    }

    private void Update()
    {
        if(target) {
            FaceToTarget(target.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.GetComponent<EnemyHealth>().DealDamage(projectileDamage);
        Destroy(gameObject);
    }

    private void FaceToTarget(Vector3 target) {
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}


