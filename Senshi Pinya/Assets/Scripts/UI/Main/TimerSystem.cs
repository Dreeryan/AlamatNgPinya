using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimerSystem : MonoBehaviour
{
    public enum TimerType { CountUp, CountDown}

    private float timer;
    private float currentTime;

    public UnityEvent OnTimerEnd;

    void Start()
    {
        StartCoroutine(StartTimer(5f));

    }

    public float GetTimeLeft(TimerType type)
    {
        if (type == TimerType.CountUp) return timer; // Starts if isCountingUp is ticked

        if (type == TimerType.CountDown) return (timer - currentTime); // Starts if isCountingDown is ticked
    }

    IEnumerator StartTimer(float seconds)
    {
        currentTime = seconds;
        Debug.Log("Timer Start");
        yield return new WaitForSeconds(seconds); // Waits for how many seconds in the start before invoking the event 
        OnTimerEnd.Invoke();
    }

    public void StopTimer()
    {
        Time.timeScale = 0f;
        StopCoroutine("StartTimer");
        Debug.Log("Stopped timer");
    }
}
