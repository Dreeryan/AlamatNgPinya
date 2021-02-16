using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : BaseManager<AudioManager>
{
    [SerializeField] private AudioDatabase audioDB;
    [SerializeField] private AudioMixer audioMix;
    [SerializeField] private float bgmFadeTime = 1;

    public float BGMFadeTime => bgmFadeTime;
    public AudioMixer AudioMix => audioMix;
    public List<AudioObject> spawnedAudio = new List<AudioObject>();

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

    public static void StopAudio(string id)
    {
        if (IdExists(id))
            GetAudioObject(id).StopAudio();
    }

    private static void PlaySFX(AudioData data)
    {
        if (IdExists(data.ID))
        {
           GetAudioObject(data.ID).PlayAudio();
        }
        else
        {
            AddAudioObject(data);
        }
    }

    private static void PlayBGM(AudioData data)
    {
        if (IdExists(data.ID))
        {
            AudioObject ao = GetAudioObject(data.ID);
            ao.PlayAudio(true);
        }
        else
        {
            AddAudioObject(data);
        }

        foreach (AudioObject ao in Instance.spawnedAudio)
        {
            if (ao.MixGroup == "SFX") continue;

            if (ao.ID != data.ID)
                ao.FadeAudio(0, Instance.bgmFadeTime);
        }
    }

    private static void AddAudioObject(AudioData toAdd)
    {
        AudioObject ao = Instance.gameObject.AddComponent<AudioObject>();

        ao.Initialize(toAdd);

        Instance.spawnedAudio.Add(ao);
    }

    private static AudioObject GetAudioObject(string id)
    {
        return Instance.spawnedAudio.Find(obj => obj.ID == id);
    }

    private static bool IdExists(string id)
    {
        return Instance.spawnedAudio.Exists(obj => obj.ID == id);
    }
}
