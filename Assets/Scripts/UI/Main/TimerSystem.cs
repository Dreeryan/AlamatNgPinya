using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private bool            countingUp;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer;
    private float timeSet;
          
    public UnityEvent OnTimerEnd;

    private void Update()
    {
        if (timerText != null)
        {
            // For testing purposes: Prints time to Text
            if (countingUp == true) timerText.text = Mathf.RoundToInt(GetTimeLeft()).ToString();

            else timerText.text = Mathf.RoundToInt(GetTimeLeft()).ToString();
        }
    }

    public float GetTimeLeft()
    {
        if (countingUp == true) return timer; 

        else return timeSet - timer; 

    }

    public IEnumerator StartTimer(float seconds)
    {
        timeSet = seconds;
        
        // Stores the timeset on call
        while (timer <= timeSet)
        {
            yield return null;
            // Timer logic
            timer += 1 * Time.deltaTime;
        }

        // Invokes when timer ends
        OnTimerEnd.Invoke();
    }

    public void StartTimers(float seconds)
    {
        StartCoroutine(StartTimer(seconds));
    }

    public void StopTimer()
    {
        StopCoroutine(StartTimer(0));
        Debug.Log("Timer Stop");
    }
}
