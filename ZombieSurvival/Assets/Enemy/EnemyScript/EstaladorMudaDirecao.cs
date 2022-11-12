using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaladorMudaDirecao : MonoBehaviour
{
    [SerializeField] private EnemyPatrolEstalador estaladorPatrol;
    [SerializeField] private Transform player;


    public void ChangeDirectionWhenHit()
    {
        float localScaleEstalador = gameObject.transform.localScale.x;

        if (player.rotation.y == 0 && localScaleEstalador == 1)
        {
            estaladorPatrol.DirectionChange();
        }
        else if (player.rotation.y != 0 && localScaleEstalador == -1)
        {
            estaladorPatrol.DirectionChange();
        }
    }

    public IEnumerator StopPatrol()
    {
        yield return new WaitForSeconds(0.01f);
        estaladorPatrol.enabled = false;
        yield return new WaitForSeconds(0.7f);
        estaladorPatrol.enabled = true;
    }


}
