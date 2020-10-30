using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private bool            CountingUp;
    [SerializeField] private TextMeshProUGUI TimerText;

    private float timer;
    private float timeSet;
          
    public UnityEvent OnTimerEnd;

    private void Update()
    {
        if (TimerText != null)
        {
            // For testing purposes: Prints time to Text
            if (CountingUp == true) TimerText.text = Mathf.RoundToInt(GetTimeLeft()).ToString();

            else TimerText.text = Mathf.RoundToInt(GetTimeLeft()).ToString();
        }
    }

    public float GetTimeLeft()
    {
        if (CountingUp == true) return timer; 

        if (CountingUp == false) return timeSet - timer; 

        else return 0f;
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
