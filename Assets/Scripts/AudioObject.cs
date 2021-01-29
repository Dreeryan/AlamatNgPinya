using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    private AudioData   aData;
    private AudioSource aSource;

    public string ID => aData.ID;

    public void Initialize(AudioData newData)
    {
        aData = newData;

        if (aData == null) return;

        aSource = this.gameObject.AddComponent<AudioSource>();

        aSource.clip = newData.AudioFile;

        aSource.outputAudioMixerGroup = AudioManager.Instance
            .AudioMix.FindMatchingGroups(newData.MixGroup)[0];

        aSource.volume = newData.Volume;

        aSource.loop = newData.IsLooping;

        aSource.Play();
    }

    public void PlayAudio()
    {
        if (aSource == null) return;

        aSource.Play();
    }
}
