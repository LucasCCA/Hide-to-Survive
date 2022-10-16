using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCloseOpcoesPausa : MonoBehaviour
{
    [SerializeField] GameObject gameObjectt;
    [SerializeField] GameObject pausaMorteGameObject;
    void Start()
    {
        gameObjectt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ClosingPausaMorteGameObject();
    }

    public void SettingsSetActive()
    {
        if (pausaMorteGameObject.activeSelf)
        {
            pausaMorteGameObject.SetActive(false);
            gameObjectt.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ClosingPausaMorteGameObject()
    {
        if(gameObjectt.activeSelf)
        {
            pausaMorteGameObject.SetActive(false);
        }
     
        
    }
}
