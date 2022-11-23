using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAILobo : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float distance;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private LoboPatrol enemyPatrol;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    public int attackDamage = 25;
    Collider2D playerColliderDetector;

    private bool ativaAtaque = false;
    public float range;

    private void Update()
    {
        playerColliderDetector = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
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
            if (ativaAtaque)
            {
                animator.SetBool("andar", false);
                enemyPatrol.enemySpeed = 3;
                animator.SetBool("loboOlhosVermelhos", true);
                animator.SetBool("loboBatendo", false);
                if (PlayerInAttackRange())
                {
                    enemyPatrol.enemySpeed = 0;
                    animator.SetBool("loboBatendo", true);
                }
            }

        }
        else
        {
            enemyPatrol.enemySpeed = 1;
            animator.SetBool("loboOlhosVermelhos", false);
            animator.SetBool("andar", true);
            animator.SetBool("loboBatendo", false);
        }

    }

    private bool PlayerInAttackRange()
    {
        if (Mathf.Abs(player.position.x - enemy.position.x) <= distance)
        {
            return true;
        }
        return false;
    }

    private float EnemyKillPlayer()
    {
        return PlayerHealth.playerCurrentHealth -= damage;
    }

    private void Attack()
    {
        //Damage
        if (playerColliderDetector != null)
        {
            sfx.Play();
            EnemyKillPlayer();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
