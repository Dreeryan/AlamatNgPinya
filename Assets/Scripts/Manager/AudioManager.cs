using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : BaseManager<AudioManager>
{
    [SerializeField] private AudioDatabase  audioDB;
    [SerializeField] private AudioMixer     audioMix;
    [SerializeField] private float          bgmFadeTime = 1;

    public float                BGMFadeTime => bgmFadeTime;
    public AudioMixer           AudioMix => audioMix;

    private List<AudioObject>   spawnedAudio = new List<AudioObject>();

    public static void PlayAudio(string idToPlay)
    {
        if (Instance == null)
        {
            Debug.LogError("AudioManager cannot be found!");
            return;
        }

        AudioData ad = Instance.audioDB.GetData(idToPlay);

        if (ad == null) return;

        if (ad.MixGroup == "SFX")
            PlaySFX(ad);
        else
            PlayBGM(ad);
    }

    private static void PlaySFX(AudioData data)
    {
        if (Instance.spawnedAudio.Exists(obj => obj.ID == data.ID))
        {
            Instance.spawnedAudio.Find(obj => obj.ID == data.ID).PlayAudio();
        }
        else
        {
            AudioObject ao = Instance.gameObject.AddComponent<AudioObject>();

            ao.Initialize(data);

            Instance.spawnedAudio.Add(ao);
        }
    }

    private static void PlayBGM(AudioData data)
    {
        if (Instance.spawnedAudio.Exists(obj => obj.ID == data.ID))
        {
            AudioObject ao = Instance.spawnedAudio.Find(obj => obj.ID == data.ID);
            ao.FadeAudio(data.Volume);
            ao.PlayAudio();
        }
        else
        {
            AudioObject ao = Instance.gameObject.AddComponent<AudioObject>();

            ao.Initialize(data);

            Instance.spawnedAudio.Add(ao);
        }

        foreach(AudioObject ao in Instance.spawnedAudio)
        {
            if (ao.ID != data.ID)
                ao.FadeAudio(0);
        }
    }
}
