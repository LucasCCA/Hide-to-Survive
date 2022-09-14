using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    [SerializeField] Slider brilhoSlider;
    [SerializeField] PostProcessProfile profile;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("brilho"))
        {
            PlayerPrefs.SetFloat("brilho", 0.5f);
        }

        Load();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBrightness();
    }

    void ChangeBrightness()
    {
        profile.GetSetting<ColorGrading>().brightness.value = brilhoSlider.value * 150 - 75;

        Save();
    }

    public void ResetBrightness()
    {
        brilhoSlider.value = 0.5f;

        Save();
    }

    void Load()
    {
        brilhoSlider.value = PlayerPrefs.GetFloat("brilho");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("brilho", brilhoSlider.value);
    }
}
