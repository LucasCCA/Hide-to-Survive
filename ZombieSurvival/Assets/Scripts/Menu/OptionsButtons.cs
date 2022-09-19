using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] GameObject videoGO;
    [SerializeField] GameObject somGO;
    [SerializeField] Button video;
    [SerializeField] Button som;

    // Update is called once per frame
    void Update()
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

    public void OnSoundPress()
    {
        somGO.SetActive(true);
        videoGO.SetActive(false);
        som.Select();
    }

    public void OnVideoPress()
    {
        somGO.SetActive(false);
        videoGO.SetActive(true);
        video.Select();
    }
}
