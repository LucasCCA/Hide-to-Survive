using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuspidorMudaDirecao : MonoBehaviour
{
    [SerializeField] private CuspidorPatrol cuspidorPatrol;
    [SerializeField] private Transform player;

    public void ChangeDirectionWhenHit()
    {
        float localScaleCuspidor = gameObject.transform.localScale.x;

        if (player.rotation.y == 0 && localScaleCuspidor == 1)
        {
            cuspidorPatrol.DirectionChange();
        }
        else if (player.rotation.y != 0 && localScaleCuspidor == -1)
        {
            cuspidorPatrol.DirectionChange();
        }
    }

    public IEnumerator StopPatrol()
    {
        yield return new WaitForSeconds(0.01f);
        cuspidorPatrol.enabled = false;
        yield return new WaitForSeconds(0.7f);
        cuspidorPatrol.enabled = true;
    }
}
