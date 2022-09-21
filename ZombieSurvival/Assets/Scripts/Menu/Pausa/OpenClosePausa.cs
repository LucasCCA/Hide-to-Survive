using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                Time.timeScale = 0f;
            }
        }
    }

    public void ClosePausa()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
