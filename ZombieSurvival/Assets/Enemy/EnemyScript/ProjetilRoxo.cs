using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilRoxo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private EnemyAIBichoEsgoto enemyAi;
    [SerializeField] private Transform bichoEsgotoTransform;
   
    void Start()
    {
        enemyAi = GetComponent<EnemyAIBichoEsgoto>();
        rb.velocity = transform.right* -1 * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameObject.transform.position.x <= bichoEsgotoTransform.position.x - enemyAi.hitSize.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if(hitInfo.CompareTag("Player") || hitInfo.CompareTag("ParaProjetil"))
        {
            Destroy(gameObject);
        }
        
    }
}
