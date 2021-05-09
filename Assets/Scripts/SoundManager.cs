﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public enum Sound
    {
        player1Attack,
        player2Flamethrower,
        player2Rocket,
        player2PulsePre,
        player2PulsePost,
    }


    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
    public SoundAudioClip[] sounds;

    //private static Dictionary<Sound, float> sountTimerDictionary;

    public void PlaySound(Sound sound)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAudioClip soundAudioClip in sounds)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }





}
