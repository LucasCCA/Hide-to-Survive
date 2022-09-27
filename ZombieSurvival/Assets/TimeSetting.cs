using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSetting : MonoBehaviour
{
    [SerializeField]GameObject pausa;
    [SerializeField] GameObject pausaOpcoes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTime();
    }

     void SetTime()
    {
        if(pausa.activeSelf || pausaOpcoes.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
