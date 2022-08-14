using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    // Start is called before the first frame update

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Move parameters")]
    [SerializeField] private float enemySpeed;

    private Vector3 initScale;
    private bool movingLeft;

    [Header("Enemy Animator")]
    [SerializeField] private Animator animator;
    void Awake()
    {
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveinDirection(-1);
            }
            else
            {
                DirectionChange();
            }
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveinDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void MoveinDirection(int direction)
    {
 
        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        float axisX = enemy.position.x + Time.deltaTime * direction * enemySpeed;
        enemy.position = new Vector3(axisX, enemy.position.y, enemy.position.z);
    }
}
