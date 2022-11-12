using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboMudaDirecao : MonoBehaviour
{
    [SerializeField] private LoboPatrol loboPatrol;
    [SerializeField] private Transform player;

    public void ChangeDirectionWhenHit()
    {
        float localScaleLobo = gameObject.transform.localScale.x;
    

        if (player.rotation.y == 0 && localScaleLobo == 1)
        {
            loboPatrol.DirectionChange();
        }
        else if (player.rotation.y != 0 && localScaleLobo == -1)
        {
            loboPatrol.DirectionChange();
        }
    }

    public IEnumerator StopPatrol()
    {
        yield return new WaitForSeconds(0.01f);       
        loboPatrol.enabled = false;
        yield return new WaitForSeconds(0.7f);
        loboPatrol.enabled = true;
        
    }
}
