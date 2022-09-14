using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    [SerializeField] Toggle muteToggle;
    bool muted;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }

        Load();
    }

    void Update()
    {
        muteToggle.isOn = muted;
        AudioListener.pause = muted;
    }

    public void MuteUnmute()
    {
        if(!muted)
        {
            muted = true;
        }
        else if(muted)
        {
            muted = false;
        }

        Save();
    }

    public void ResetMute()
    {
        muted = false;

        Save();
    }

    void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
