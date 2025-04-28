using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip normalTheme;

    public AudioClip sadTheme;
    public AudioClip intenseTheme;

    private void Start()
    {
        if (normalTheme != null)
        {
            musicSource.clip = normalTheme;
            musicSource.Play();
        }
        
        musicDictionary.Add("normal", normalTheme);
        musicDictionary.Add("sad", sadTheme);
        musicDictionary.Add("intense", intenseTheme);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ChangeMusic(string musicName)
    {
        musicSource.Stop();
        
        var clip = musicDictionary[musicName];
        musicSource.clip = clip;
        
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
}
