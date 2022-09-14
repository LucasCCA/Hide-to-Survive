using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSettings : MonoBehaviour
{
    [SerializeField] MuteAudio muteAudio;
    [SerializeField] Volume volume;
    [SerializeField] Brightness brightness;
    [SerializeField] Fullscreen fullScreen;

    // Update is called once per frame
    void Update()
    {
        ResetAllSettings();
    }

    void ResetAllSettings()
    {
        if(Input.GetButtonDown("Reload"))
        {
            muteAudio.ResetMute();
            volume.ResetAudio();
            brightness.ResetBrightness();
            fullScreen.ResetFullScreen();
        }
    }
}
