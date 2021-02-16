using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioObject : MonoBehaviour
{
    private AudioData   aData;
    private AudioSource aSource;

    public string ID => aData.ID;
    public string MixGroup => aData.MixGroup;

    private float currVolume;

    public void Initialize(AudioData newData)
    {
        aData = newData;

        if (aData == null) return;

        aSource = this.gameObject.AddComponent<AudioSource>();

        aSource.clip = newData.AudioFile;
	
		if(AudioManager.Instance.AudioMix != null)
			aSource.outputAudioMixerGroup = AudioManager.Instance
				.AudioMix.FindMatchingGroups(newData.MixGroup)[0];

        if (newData.MixGroup == "Music")
        {
            aSource.volume = 0;
            currVolume = 0;
            FadeAudio(newData.Volume);
        }
        else
        {
            aSource.volume = newData.Volume;
            currVolume = newData.Volume;
        }

        aSource.loop = newData.IsLooping;

        aSource.Play();
    }

    public void PlayAudio()
    {
        if (aSource == null)
        {
            Debug.LogError("Lost Audio Source!");
            return;
        }

        aSource.Play();
    }

    public void StopAudio()
    {
        if (aSource == null) return;
        aSource.Stop();
    }

    public void FadeAudio(float targetVol)
    {
        aSource.DOFade(targetVol, AudioManager.Instance.BGMFadeTime);
    }

    public void FadeStopAudio()
    {
        float stopTime = AudioManager.Instance.BGMFadeTime;
        aSource.DOFade(0, stopTime);
        StartCoroutine(DelayedStopCR(stopTime));
    }

    private IEnumerator DelayedStopCR(float delay)
    {
        yield return new WaitForSeconds(delay);
        aSource.Stop();
    }
}
