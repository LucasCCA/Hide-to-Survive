using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFirePOint : MonoBehaviour
{
    [SerializeField] private Transform cuspidor;
    private bool jaRotacionou = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFireDirection();
    }

    private void ChangeFireDirection()
    {
        if(cuspidor.localScale.x < 0)
        {
            if(jaRotacionou == false)
            {
                transform.Rotate(0f, 180f, 0f);
                jaRotacionou = true;
            }
            
        }
        else
        {
            if(jaRotacionou)
            {
                transform.Rotate(0f, 180f, 0f);
                jaRotacionou = false;
            }
        }
    }
}
