using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject opcoesGO;
    [SerializeField] GameObject videoGO;
    [SerializeField] GameObject somGO;
    [SerializeField] Button brilho;
    [SerializeField] Button volume;

    // Update is called once per frame
    void Update()
    {
        if(opcoesGO.activeSelf)
        {
            if (Input.GetButtonDown("Fire4"))
            {
                OnVideoPress();
            }

            if (Input.GetButtonDown("Fire3"))
            {
                OnSoundPress();
            }
        }
    }

    public void OnOptionsPress()
    {
        menuPrincipal.SetActive(false);
        opcoesGO.SetActive(true);
        brilho.Select();
    }

    public void OnSoundPress()
    {
        somGO.SetActive(true);
        videoGO.SetActive(false);
        volume.Select();
    }

    public void OnVideoPress()
    {
        somGO.SetActive(false);
        videoGO.SetActive(true);
        brilho.Select();
    }
}
