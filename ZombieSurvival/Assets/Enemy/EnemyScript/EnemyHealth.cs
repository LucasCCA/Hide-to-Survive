using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int enemyMaxHealth = 100;
    public int enemyCurrentHealth;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        KillEnemy();
    }

    public int DiminuiVida(int danoLevado)
    {
        return enemyCurrentHealth -= danoLevado;
    }
    
    private void KillEnemy()
    {
        if(enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }        
    }
}