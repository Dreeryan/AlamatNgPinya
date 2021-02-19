using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugFeed : MonoBehaviour
{
    public TMP_Text OnFeedArea;
    public TMP_Text IsShaking;

    public ShakeObject shake;

    // Update is called once per frame
    void Update()
    {
        OnFeedArea.text =  string.Format("OnFeedArea: {0}",shake.IsOnFeedArea.ToString());
        IsShaking.text = string.Format("IsShaking: {0}", shake.IsShaking.ToString());
    }
}
