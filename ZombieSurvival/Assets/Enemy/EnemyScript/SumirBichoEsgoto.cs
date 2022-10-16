using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumirBichoEsgoto : MonoBehaviour
{
    [SerializeField] private Transform bichoEsgoto;
    [SerializeField] private Transform player;
    [SerializeField] private int range;
    [SerializeField] private Animator anim;

    private void Update()
    {
        DefinirDistanciaEntrePlayerBicho();
    }
    private void DefinirDistanciaEntrePlayerBicho()
    {
        if (player.position.x >=  bichoEsgoto.position.x - range)
        {
            EnemyShoot scriptEnemyShoot = GetComponent<EnemyShoot>();
            scriptEnemyShoot.enabled = false;
            anim.SetTrigger("sumirEsgoto");

        }
    }
}
