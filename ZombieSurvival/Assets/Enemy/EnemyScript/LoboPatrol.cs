using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Move parameters")]
    public float enemySpeed;
    [SerializeField] private EnemyAILobo enemyAI;

    [SerializeField] Animator anim;
    private Vector3 initScale;
    private bool movingLeft;
    void Awake()
    {
        anim.SetBool("andar", true);
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
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
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        float axisX = enemy.position.x + Time.deltaTime * direction * enemySpeed;
        enemy.position = new Vector3(axisX, enemy.position.y, enemy.position.z);
    }

    private void UpdateRangeWhenInLeft()
    {
        enemyAI.range = Mathf.Abs(enemy.position.x - leftEdge.position.x) / 2.8f;
    }

    private void UpdateRangeWhenInRight()
    {
        enemyAI.range = Mathf.Abs(rightEdge.position.x - enemy.position.x) / 2.8f;
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
