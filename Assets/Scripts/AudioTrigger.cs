using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public void PlayAudio(string audioId)
    {
        AudioManager.PlayAudio(audioId);
    }

    public void StopAudio(string audioId)
    {
        AudioManager.StopAudio(audioId);
    }
}
