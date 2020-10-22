using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public enum TimerType
{
    CountUp,
    CountDown
}

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer;
    private float timeSet;
          
    public UnityEvent OnTimerEnd;

    private void Update()
    {
        // For testing purposes
        timerText.text = Mathf.RoundToInt(GetTimeLeft(TimerType.CountUp)).ToString();
    }

    public float GetTimeLeft(TimerType type)
    {
        if (type == TimerType.CountUp) return timer; 

        if (type == TimerType.CountDown) return timeSet -timer; 

        else return 0f;
    }

    private IEnumerator StartTimer(float seconds)
    {
        // Stores the timeset on call
        timeSet = seconds;

        while (timer <= timeSet)
        {
            // Timer logic
            timer += 1 * Time.deltaTime;
        }
        // Invokes when timer ends
        OnTimerEnd.Invoke();
        yield return new WaitForSeconds(0.1f);
    }

    public void StartTimers(float seconds)
    {
        StartCoroutine(StartTimer(seconds));
    }

    public void StopTimer()
    {
        StopCoroutine("StartTimer");
        Debug.Log("Stopped timer");
    }
}
