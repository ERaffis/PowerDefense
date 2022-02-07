using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        EnnemyHit,
        Cable,
        SocketIn,
        Button,
        
    }

    private static Dictionary<Sound, float> soundTimerDictionnary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public static void Initialize()
    {
        soundTimerDictionnary = new Dictionary<Sound, float>();
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();

            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }


    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
        }
    }


    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
