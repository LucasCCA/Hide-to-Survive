using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoBackScene : MonoBehaviour
{
    [SerializeField] GameObject destinyScene;
    [SerializeField] GameObject otherScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GoBack();
        }
    }

    public void GoBack()
    {
        destinyScene.SetActive(true);
        otherScene.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
