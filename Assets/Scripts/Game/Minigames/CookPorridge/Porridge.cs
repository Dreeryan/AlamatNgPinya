using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Porridge : MonoBehaviour
{
    private float currentTemp = 0.0f;
    private bool isRightTemp = false;
    private bool hasWon = false;

    [Header("Porridge Settings")]
    [SerializeField] private float maxTemp = 100.0f;
    [SerializeField] private float rightTemp = 30f;
    [SerializeField] private float addTemperature;
    [SerializeField] private float decreaseTemperature;
    [SerializeField] private float secondsToUndercooked;
    [SerializeField] private float secondsToCooked;
    [SerializeField] private float secondsToWin;

    [Header("Animator")]
    public Animator fireAnimator;
    public Animator potCoverAnimator;

    [Header("UI")]
    [SerializeField] private Slider porridgeSlider;

    [Header("References")]
    [SerializeField] private Counter counter;


    [Header("Sound Settings")]
    [SerializeField] private string softBoilSFX;
    [SerializeField] private string regularBoilSFX;
    [SerializeField] private string hardBoilSFX;

    [SerializeField] private UnityEvent onFireTurnOn;
    [SerializeField] private UnityEvent onUndercooked;
    [SerializeField] private UnityEvent onSlightlyCooked;
    [SerializeField] private UnityEvent onCooked;

    void Update()
    {
        if (!hasWon && !GameManager.Instance.IsPaused)
        {
            // Getting the current temp from the slider value
            currentTemp = (int)(porridgeSlider.value * 100);
            
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (currentTemp == 0) OnSoftBoil();
                porridgeSlider.value += addTemperature * Time.deltaTime;

                if (currentTemp >= maxTemp) currentTemp = maxTemp;
            }
            else
            {
                porridgeSlider.value -= decreaseTemperature * Time.deltaTime;

                if (currentTemp <= 0) currentTemp = 0;
            }

            #region Animation

            fireAnimator.SetFloat("Temp", currentTemp);
            potCoverAnimator.SetFloat("Temp", currentTemp);

            if (currentTemp > 0)
            {
                fireAnimator.SetBool("isFireOn", true);
                potCoverAnimator.SetBool("isFireOn", true);
            }
            else
            {
                fireAnimator.SetBool("isFireOn", false);
                potCoverAnimator.SetBool("isFireOn", false);
            }

            #endregion

            if (currentTemp > rightTemp && !isRightTemp)
            {
                StartCoroutine(RightTempCountdown());
            }
            else if (currentTemp < rightTemp)
            {
                StopCoroutine(RightTempCountdown());
                isRightTemp = false;
            }
        }
    }

    void OnSoftBoil()
    {
        AudioManager.PlayAudio(softBoilSFX);
        AudioManager.StopAudio(regularBoilSFX);
        AudioManager.StopAudio(hardBoilSFX);
    }
    void OnRegularBoil()
    {
        AudioManager.StopAudio(softBoilSFX);
        AudioManager.PlayAudio(regularBoilSFX);
        AudioManager.StopAudio(hardBoilSFX);
    }
    void OnHardBoil()
    {
        AudioManager.StopAudio(softBoilSFX);
        AudioManager.StopAudio(regularBoilSFX);
        AudioManager.PlayAudio(hardBoilSFX);
    }

    void StopAudio()
    {
        AudioManager.StopAudio(softBoilSFX);
        AudioManager.StopAudio(regularBoilSFX);
        AudioManager.StopAudio(hardBoilSFX);
    }

    IEnumerator RightTempCountdown()
    {
        isRightTemp = true;

        yield return new WaitForSeconds(secondsToUndercooked);

        OnRegularBoil();

        yield return new WaitForSeconds(secondsToCooked);

        OnHardBoil();

        potCoverAnimator.SetBool("isCooked", true);
        onCooked?.Invoke();
        yield return new WaitForSeconds(secondsToWin);
        StopAudio();
        hasWon = true;

        WinCheck.Instance.IncreaseProgress();
    }
}
