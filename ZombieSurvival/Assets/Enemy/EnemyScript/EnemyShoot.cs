using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    public EnemyAIBichoEsgoto enemyAIEsgoto;
    [SerializeField] private Animator anim;
    private float nextAttackTime = 0f;
    private bool ativaAtaque = false;
    //[SerializeField] float velocity = 4f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyAIEsgoto.PlayerInSight())
        {
            ativaAtaque = true;
        }
        if (ativaAtaque)
        {
            anim.SetTrigger("aparecerEsgoto");
            
            if(Time.time >= nextAttackTime)
            {
                Shoot();
                nextAttackTime = Time.time + 4f;
            }
           
        }

        
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }









}
