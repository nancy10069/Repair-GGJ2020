using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGMAudioSource, SFXAudioSource;
    public List<AudioClip> levelBGMs;
    public List<AudioClip> sfxAudios;
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void PlayBGM(int levelIndex)
    {
        //levelIndex = levelIndex % levelBGMs.Count;
        //BGMAudioSource.clip = levelBGMs[levelIndex];
        //BGMAudioSource.Play();
    }

    public enum SFXCategory
    {
        None = -1,
        VacuumCleanerLooping = 0,
        ExplosionOneShot = 1,
        ChainsawLooping =2,

    }

    public void PlaySFX(SFXCategory sfx)
    {
        SFXAudioSource.PlayOneShot(sfxAudios[(int)sfx]);
    }

    internal void StopSFX()
    {
        SFXAudioSource.Stop();
    }
}
