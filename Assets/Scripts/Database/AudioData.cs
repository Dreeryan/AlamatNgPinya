using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData : BaseData
{
    [SerializeField] private List<AudioClip>    audioFile;
    [SerializeField] private float              volume;
    [SerializeField] private string             mixGroup;
    [SerializeField] private bool               isLooping;

    public List<AudioClip>  AudioFile => audioFile; 
    public float            Volume => volume;
    public string           MixGroup => mixGroup;
    public bool             IsLooping =>  isLooping; 
}
