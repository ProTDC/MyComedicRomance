using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip musicClip;
    public AudioClip sfxClip;

    private void Start()
    {
        if (musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        if (sfxClip != null)
        {
            sfxSource.clip = sfxClip;
        }
    }

    public void ChangeMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
}
