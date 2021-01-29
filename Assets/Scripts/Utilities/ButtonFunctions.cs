using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
   public void PlayAudio(string audioId)
    {
        AudioManager.PlayAudio(audioId);
    }
}
