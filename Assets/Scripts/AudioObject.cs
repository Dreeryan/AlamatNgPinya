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

    public void Initialize(AudioData newData)
    {
        aData = newData;

        if (aData == null) return;

        aSource = this.gameObject.AddComponent<AudioSource>();

        aSource.clip = newData.AudioFile;
	
		if(AudioManager.Instance.AudioMix != null)
			aSource.outputAudioMixerGroup = AudioManager.Instance
				.AudioMix.FindMatchingGroups(newData.MixGroup)[0];

        aSource.volume = newData.Volume;
        aSource.loop = newData.IsLooping;

        aSource.Play();
    }

    public void PlayAudio(bool fadeIn = false)
    {
        if (aSource == null)
        {
            Debug.LogError("Lost Audio Source!");
            return;
        }

        aSource.Play();

        if (aSource.volume <= 0 && fadeIn)
            FadeAudio(aData.Volume, AudioManager.Instance.BGMFadeTime);
    }

    public void StopAudio()
    {
        if (aSource == null) return;
        aSource.Stop();
    }

    public void FadeAudio(float targetVol, float duration)
    {
        aSource.DOFade(targetVol, duration).SetUpdate(true);
    }

    private IEnumerator DelayedStopCR(float delay)
    {
        yield return new WaitForSeconds(delay);
        aSource.Stop();
    }
}
