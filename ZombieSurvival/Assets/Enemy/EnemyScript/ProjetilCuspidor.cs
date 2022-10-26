using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilCuspidor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Player"))
        {
            EnemyKillPlayer();
            Destroy(gameObject);
        }
        else if (hitInfo.CompareTag("ParaProjetil"))
        {
            Destroy(gameObject);
        }

    }

    public float EnemyKillPlayer()
    {
        return PlayerHealth.playerCurrentHealth -= damage;
    }
}
