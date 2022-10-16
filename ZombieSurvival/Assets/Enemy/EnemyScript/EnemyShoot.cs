using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    public EnemyAIBichoEsgoto enemyAIEsgoto;
    [SerializeField] private Animator anim;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAIEsgoto.PlayerInSight())
        {
            anim.SetTrigger("aparecerEsgoto");
            
            if(Time.time >= nextAttackTime)
            {
                Shoot();
                nextAttackTime = Time.time + 2f;
            }
           
        }
        else
        {
            anim.SetTrigger("sumirEsgoto");
        }
        
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }









}
