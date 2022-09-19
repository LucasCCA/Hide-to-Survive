using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDeselected : MonoBehaviour
{
    [SerializeField] Button button;

    void Update()
    {
        SelectButton();
    }

    void SelectButton()
    {
        float value = Input.GetAxisRaw("Vertical");
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (value != 0)
            {
                button.Select();
            }
        }
    }
}
