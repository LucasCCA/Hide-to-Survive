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
    void Awake()
    {
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MoveinDirection(1);
    }

    private void MoveinDirection(int direction)
    {
        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        float axisX = enemy.position.x + Time.deltaTime * direction * enemySpeed;
        enemy.position = new Vector3(axisX, enemy.position.y, enemy.position.z);
    }
}
