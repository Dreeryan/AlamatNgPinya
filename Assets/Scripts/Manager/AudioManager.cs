using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : BaseManager<AudioManager>
{
    [SerializeField] private AudioDatabase  audioDB;
    [SerializeField] private AudioMixer     audioMix;

    public AudioMixer AudioMix => audioMix;

    private List<AudioObject> spawnedAudio = new List<AudioObject>();

    public static void PlayAudio(string idToPlay)
    {
        if(Instance == null)
        {
            Debug.LogError("AudioManager cannot be found!");
            return;
        }

        if (Instance.spawnedAudio.Exists(obj => obj.ID == idToPlay))
        {
            Instance.spawnedAudio.Find(obj => obj.ID == idToPlay).PlayAudio();
        }
        else
        {
            AudioData ad = Instance.audioDB.GetData(idToPlay);

            if (ad == null) return;

            AudioObject ao = Instance.gameObject.AddComponent<AudioObject>();

            ao.Initialize(ad);

            Instance.spawnedAudio.Add(ao);         
        }
    }
}
