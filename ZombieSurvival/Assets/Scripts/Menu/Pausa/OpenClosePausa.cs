using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenClosePausa : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectt;
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
            if (gameObjectt.activeSelf)
            {
                ClosePausa();
            }
            else
            {
                gameObjectt.SetActive(true);
            }
        }
    }

    public void ClosePausa()
    {
        gameObjectt.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
