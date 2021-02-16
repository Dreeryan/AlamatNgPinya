using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// Instance holder for the audio source
/// </summary>
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

    /// <summary>
    /// Play the audio clip
    /// </summary>
    /// <param name="fadeIn">Fade in to set volume if curremt volume is 0</param>
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

    /// <summary>
    /// Fade the audio volume by tween
    /// </summary>
    /// <param name="targetVol"> New volume value</param>
    /// <param name="duration"> Duration of tween</param>
    public void FadeAudio(float targetVol, float duration)
    {
        aSource.DOFade(targetVol, duration).SetUpdate(true);
    }
}
