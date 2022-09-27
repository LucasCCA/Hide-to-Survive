using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenClosePausa : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void Start()
    {
        ClosePausa();
    }

    // Update is called once per frame
    void Update()
    {
        OpenClose();
    }

    void OpenClose()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameObject.activeSelf)
            {
                ClosePausa();
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }

    public void ClosePausa()
    {
        gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
