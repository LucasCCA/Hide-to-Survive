using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventPauseFromOpen : MonoBehaviour
{
    [SerializeField] GameObject gameObjectPausa;
    [SerializeField] GameObject gameObjectMorte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PreventPause();
    }

    void PreventPause()
    {
        if(gameObjectMorte.activeSelf)
        {
            gameObjectPausa.SetActive(false);
        }
    }

}
