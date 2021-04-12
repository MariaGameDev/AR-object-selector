using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundManager : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.PlaySound(AudioManager.SoundType.Click);
    }
}
