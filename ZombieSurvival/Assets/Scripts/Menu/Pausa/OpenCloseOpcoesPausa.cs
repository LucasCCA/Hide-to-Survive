using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCloseOpcoesPausa : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] GameObject pausaMorteGameObject;
    void Start()
    {
        gameObject.SetActive(false);
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
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ClosingPausaMorteGameObject()
    {
        if(gameObject.activeSelf)
        {
            pausaMorteGameObject.SetActive(false);
        }
     
        
    }
}