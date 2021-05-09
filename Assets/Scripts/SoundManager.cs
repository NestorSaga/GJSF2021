using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public enum Sound
    {
        player1Attack,
        playerHurt,
        player2Flamethrower1,
        player2Flamethrower2,
        player2RocketFlying,
        player2RocketExplode,
        player2PulsePre,
        player2PulsePost,
        diablilloSound,
        BGM,
    }

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        
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
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
        audioSource.volume = 1f;

        Object.Destroy(soundGO, audioSource.clip.length);

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
