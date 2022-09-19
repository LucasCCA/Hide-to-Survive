using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsVoltarNav : MonoBehaviour
{
    public void VoltarNav()
    {
        float value = Input.GetAxisRaw("Vertical");

        if(value < 0)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
