using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class DebugVolumeController : MonoBehaviour
{
    //[SerializeField] private Toggle enableOverride;
    [SerializeField] private string mixGroup;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;

    private AudioMixer mixer;


    #region sliderValues
    float curMin = -80f;
    float curMax = 0f;

    float newMin = 0f;
    float newMax = 100f;

    float curRange => curMax - curMin;
    float newRange => newMax - newMin;

    #endregion
    private void OnEnable()
    {
        slider.onValueChanged.AddListener(ModifyVolume);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(ModifyVolume);
    }

    // Start is called before the first frame update
    void Start()
    {
        mixer = AudioManager.Instance.AudioMix;

        if (mixer == null) return;

        mixer.GetFloat(mixGroup, out float volume);
        slider.value = volume;

        slider.minValue = curMin;
        slider.maxValue = curMax;

    }

    void UpdateText(float val)
    {
        // scaling formula
        float converted = ((val - curMin) * newRange / curRange) + newMin;

        text.text = string.Format("{0}", System.Math.Round(converted, 0));
    }

    void ModifyVolume(float volume)
    {
        AudioMixer mixer = AudioManager.Instance.AudioMix;

        mixer.SetFloat(mixGroup, volume);

        UpdateText(volume);
    }
}
