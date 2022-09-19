using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject destinyScene;
    [SerializeField] GameObject otherScene;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        destinyScene.SetActive(true);
        otherScene.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
