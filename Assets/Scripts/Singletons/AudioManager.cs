using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
    private static GameObject soundObject;
    private static AudioSource audioSource;
    public enum SoundType
    {
        Click,
        Junk,
        RecStart,
        RecStop,
        DeleteAllObjs,
        DeleteAsset
    }
    public static void PlaySound(SoundType sound) 
    {
        if (soundObject == null) 
        {
            soundObject = new GameObject("Sound");
            audioSource = soundObject.AddComponent<AudioSource>();
        }
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(SoundType sound) 
    {
        foreach (UIAudioAssets.SoundAudioClip soundAudioClip in UIAudioAssets.i.soundAudioClips)
        {
            if (soundAudioClip.sound == sound) 
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }
}