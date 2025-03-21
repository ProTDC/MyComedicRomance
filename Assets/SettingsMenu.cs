using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;
    
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height}";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        if (PlayerPrefs.HasKey("musicFloat"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            PlayerPrefs.Save();
        }
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("musicVolume",  Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicFloat", volume);
        PlayerPrefs.Save();
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxFloat", volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicFloat");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxFloat");

        SetMusicVolume();
        SetSFXVolume();
        PlayerPrefs.Save();
    }
}
