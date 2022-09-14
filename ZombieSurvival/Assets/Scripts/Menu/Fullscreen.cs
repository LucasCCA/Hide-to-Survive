using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    [SerializeField] Toggle fullScreenToggle;
    bool fullScreen = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("fullScreen"))
        {
            PlayerPrefs.SetInt("fullScreen", 1);
        }
        Load();
    }

    void Update()
    {
        fullScreenToggle.isOn = fullScreen;
        Screen.fullScreen = fullScreen;
    }

    public void SetFullScreen()
    {
        if (!fullScreen)
        {
            fullScreen = true;
        }
        else if (fullScreen)
        {
            fullScreen = false;
        }

        Save();
    }

    public void ResetFullScreen()
    {
        fullScreen = true;

        Save();
    }

    void Load()
    {
        fullScreen = PlayerPrefs.GetInt("fullScreen") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("fullScreen", fullScreen ? 1 : 0);
    }
}
