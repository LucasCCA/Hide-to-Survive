using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDeselected : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject NiveisGO;

    void Update()
    {
        SelectButton();
        SelectNiveis();
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

    void SelectNiveis()
    {
        float valueVertical = Input.GetAxisRaw("Vertical");
        float valueHorizontal = Input.GetAxisRaw("Horizontal");

        if (NiveisGO != null)
        {
            if (NiveisGO.activeSelf)
            {
                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    if (valueHorizontal != 0 || valueVertical != 0)
                    {
                        button.Select();
                    }
                }
            }
        }
    }
}
