using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    private AudioData   aData;
    private AudioSource aSource;

    public string ID => aData.ID;

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
        if (aSource == null) return;

        aSource.Play();
    }

    public void StopAudio()
    {
        if (aSource == null) return;
        aSource.Stop();
    }

    public void FadeAudio(float targetVol)
    {
        StartCoroutine(LerpAudioVolumeCR(targetVol));
    }

    private IEnumerator LerpAudioVolumeCR(float targetVol)
    {
        float timeElapsed = 0;
        float initVal = currVolume;
        float lerpTime = AudioManager.Instance.BGMFadeTime;

        while (timeElapsed < lerpTime)
        {
            currVolume = Mathf.Lerp(initVal, targetVol, timeElapsed / lerpTime);
            timeElapsed += Time.deltaTime;

            aSource.volume = currVolume;
            yield return null;
        }

        currVolume = targetVol;
        aSource.volume = currVolume;
    }
}
