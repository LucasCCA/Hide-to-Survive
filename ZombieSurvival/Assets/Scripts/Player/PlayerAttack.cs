using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    public int attackDamage = 25;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] PlayerMovement pm;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");

        StartCoroutine(StopWalking());

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("acertou"); //enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
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

    IEnumerator StopWalking()
    {
        pm.enabled = false;

        yield return new WaitForSeconds(0.5f);

        pm.enabled = true;
    }
}
