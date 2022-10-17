using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAICuspidor : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float colliderDistance;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private CuspidorPatrol enemyPatrol;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;

    private bool ativaAtaque = false;
    public float range;

    private void Update()
    {
        SetAttack();
    }

    private bool PlayerinSight()
    {
        Vector2 hitOrigin = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 hitSize = new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z);
        RaycastHit2D hit = Physics2D.BoxCast(hitOrigin, hitSize, 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Vector2 hitDrawCenter = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 hitDrawSize = new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hitDrawCenter, hitDrawSize);
    }
    private void SetAttack()
    {
        if (PlayerinSight())
        {
            ativaAtaque = true;
            if(ativaAtaque)
            {
                animator.SetBool("andar", false);
                enemyPatrol.enabled = false;
                animator.SetBool("cuspirBool", true);
            }

        }
        else
        {
            animator.SetBool("cuspirBool", false);
            animator.SetBool("andar", true);
            enemyPatrol.enabled = true;
        }

    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyKillPlayer();
        }
    }
    private float EnemyKillPlayer()
    {
        return PlayerHealth.playerCurrentHealth -= damage;
    }
}
