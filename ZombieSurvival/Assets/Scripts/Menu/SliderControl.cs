using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SliderControl : MonoBehaviour
{
    [SerializeField] Slider slider;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Control()
    {
        float value = Input.GetAxisRaw("Horizontal");

        if(value > 0)
        {
            slider.value += 0.003f;
        }
        else if(value < 0)
        {
            slider.value -= 0.003f;
        }

    }
}
