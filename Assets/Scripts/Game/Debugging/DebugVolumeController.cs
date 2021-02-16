using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class DebugVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle enableOverride;
    [SerializeField] private GameObject panel;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;
    [SerializeField] private KeyCode toggleKey = KeyCode.F2;

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
        mixer.GetFloat("Master", out float volume);
        slider.value = volume;

        slider.minValue = -80f;
        slider.maxValue = 0f;

        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey)) panel.SetActive(!panel.activeSelf);
    }

    void UpdateText(float val)
    {
        float oldMin = -80f;
        float oldMax = 0f;
        float oldRange = oldMax - oldMin;

        float newMin = 0f;
        float newMax = 100f;
        float newRange = newMax - newMin;

        float converted = ((val - oldMin) * newRange / oldRange) + newMin;


        text.text = string.Format("Volume: {0}", System.Math.Round(converted, 0));
    }

    void ModifyVolume(float volume)
    {
        AudioMixer mixer = AudioManager.Instance.AudioMix;

        mixer.SetFloat("Master", volume);

        UpdateText(volume);
    }
}
