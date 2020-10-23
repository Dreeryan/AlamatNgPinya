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
    [SerializeField] private TextMeshProUGUI countUpTimerText;
    [SerializeField] private TextMeshProUGUI countDownTimerText;

    private float timer;
    private float timeSet;
          
    public UnityEvent OnTimerEnd;

    private void Update()
    {
        // For testing purposes: Prints time to Text
        countUpTimerText.text = Mathf.RoundToInt(GetTimeLeft(TimerType.CountUp)).ToString();
        countDownTimerText.text = Mathf.RoundToInt(GetTimeLeft(TimerType.CountDown)).ToString();
    }

    public float GetTimeLeft(TimerType type)
    {
        if (type == TimerType.CountUp) return timer; 

        if (type == TimerType.CountDown) return timeSet - timer; 

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
        Debug.Log("Work");
    }
}
