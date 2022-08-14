using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private Animator animator;
    
    
  
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        EstaladorAttack();
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
    private void EstaladorAttack()
    {
        if (PlayerinSight())
        {
            animator.SetTrigger("levantaMaoo");
            animator.SetBool("ataqueEstalador", true);
           
        }
        else
        {
            animator.ResetTrigger("levantaMaoo");
            animator.SetBool("ataqueEstalador", false);
        }

    }

    private void DamagePlayer()
    {
        if(PlayerinSight())
        {

        }
    }
}
