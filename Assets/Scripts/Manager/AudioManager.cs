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
    private List<AudioObject> spawnedAudio = new List<AudioObject>();

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
            Instance.spawnedAudio.Find(obj => obj.ID == id).StopAudio();
    }

    private static void PlaySFX(AudioData data)
    {
        if (IdExists(data.ID))
        {
            Instance.spawnedAudio.Find(obj => obj.ID == data.ID).PlayAudio();
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
            AudioObject ao = Instance.spawnedAudio.Find(obj => obj.ID == data.ID);
            ao.FadeAudio(data.Volume);
            ao.PlayAudio();
        }
        else
        {
            AddAudioObject(data);
        }

        foreach(AudioObject ao in Instance.spawnedAudio)
        {
            if (ao.ID != data.ID)
                ao.FadeAudio(0);
        }
    }

    private static void AddAudioObject(AudioData toAdd)
    {
        AudioObject ao = Instance.gameObject.AddComponent<AudioObject>();

        ao.Initialize(toAdd);

        Instance.spawnedAudio.Add(ao);
    }

    private static bool IdExists(string id)
    {
        return Instance.spawnedAudio.Exists(obj => obj.ID == id);
    }
}
