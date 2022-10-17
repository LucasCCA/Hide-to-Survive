using UnityEngine;

public class EnemyPatrolEstalador : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Move parameters")]
    public float enemySpeed;
    [SerializeField]private EnemyAIEstalador1 enemyAI;

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
                UpdateCourseLeft();
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
                UpdateCourseRight();
            }
            else
            {
                DirectionChange();
            }
        }
        
    }

    public void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    public void MoveinDirection(int direction)
    {
         enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        float axisX = enemy.position.x + Time.deltaTime * direction * enemySpeed;
        enemy.position = new Vector3(axisX, enemy.position.y, enemy.position.z);
    }

    private void UpdateRangeWhenInLeft()
    {
        enemyAI.range =  (Mathf.Abs(enemy.position.x - leftEdge.position.x ))/2;
    }

    private void UpdateRangeWhenInRight()
    {
        enemyAI.range = (Mathf.Abs(rightEdge.position.x - enemy.position.x))/2;
    }

    public void UpdateCourseLeft()
    {
        MoveinDirection(-1);
        UpdateRangeWhenInLeft();
    }

    public void UpdateCourseRight()
    {
        MoveinDirection(1);
        UpdateRangeWhenInRight();
    }
}