using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClosePausa : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void Start()
    {
        gameObject.SetActive(false);
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
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }

}
