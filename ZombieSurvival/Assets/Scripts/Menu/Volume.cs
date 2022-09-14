using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
        }

        Load();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVolume();
    }

    void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;

        Save();
    }

    public void ResetAudio()
    {
        volumeSlider.value = 1f;

        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
