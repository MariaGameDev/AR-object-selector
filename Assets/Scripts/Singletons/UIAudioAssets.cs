using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioAssets : MonoBehaviour
{
    private static UIAudioAssets _i;

    public static UIAudioAssets i 
    {
        get 
        {
            if (_i == null) _i = (Instantiate(Resources.Load("Sounds/UIAudioAssets")) as GameObject).GetComponent<UIAudioAssets>();
            return _i;
        }
    }

    //Set public references below
    public SoundAudioClip[] soundAudioClips;

    [System.Serializable]
    public class SoundAudioClip 
    {
        public AudioManager.SoundType sound;
        public AudioClip audioClip;
    }
}
