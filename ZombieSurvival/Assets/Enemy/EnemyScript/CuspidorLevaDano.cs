using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuspidorLevaDano : MonoBehaviour
{
    [SerializeField] private CuspidorPatrol cuspidorPatrol;
    [SerializeField] private EnemyAICuspidor cuspidorAI;
    [SerializeField] private Transform player;

    public void ChangeDirectionWhenHit()
    {
        float localScaleCuspidor = gameObject.transform.localScale.x;
        cuspidorAI.enabled = false;
        if (player.localScale.x == 1 && localScaleCuspidor == player.localScale.x)
        {
            cuspidorPatrol.DirectionChange();
        }
        else if (player.localScale.x == -1 && localScaleCuspidor == player.localScale.x)
        {
            cuspidorPatrol.DirectionChange();
        }
    }

    public IEnumerator StopPatrol()
    {
        yield return new WaitForSeconds(0.01f);
        cuspidorPatrol.enabled = false;
        yield return new WaitForSeconds(0.7f);
        cuspidorAI.enabled = true;
        cuspidorPatrol.enabled = true;
    }
}
