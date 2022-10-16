using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaladorLevaDano : MonoBehaviour
{
    [SerializeField] private EnemyPatrolEstalador estaladorPatrol;
    [SerializeField] private EnemyAIEstalador1 estaladorAI;
    [SerializeField] private Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirectionWhenHit()
    {
        float localScaleEstalador = gameObject.transform.localScale.x;
        estaladorAI.enabled = false;
        if (player.localScale.x == 1 && localScaleEstalador == player.localScale.x)
        {
            estaladorPatrol.DirectionChange();
        }
        else if(player.localScale.x == -1 && localScaleEstalador == player.localScale.x)
        {
            estaladorPatrol.DirectionChange();
        }
    }

    public IEnumerator StopPatrol()
    {
        yield return new WaitForSeconds(0.01f);
        estaladorPatrol.enabled = false;
        yield return new WaitForSeconds(0.7f);
        estaladorAI.enabled = true;
        estaladorPatrol.enabled = true;
    }


}
