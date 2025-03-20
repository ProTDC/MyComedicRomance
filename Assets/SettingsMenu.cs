using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;
    
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
