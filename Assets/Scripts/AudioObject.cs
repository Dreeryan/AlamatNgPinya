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

        aSource.volume = newData.Volume;
        currVolume = newData.Volume;

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

        if (aSource.volume <= 0)
            aSource.volume = 1;
    }

    public void StopAudio()
    {
        if (aSource == null) return;
        aSource.Stop();
    }

    private IEnumerator DelayedStopCR(float delay)
    {
        yield return new WaitForSeconds(delay);
        aSource.Stop();
    }
}
