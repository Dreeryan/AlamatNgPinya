using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
//A: You dont need an enum for this. You can just use a bool if its only 2 arguments
public enum TimerType
{
    CountUp,
    CountDown
}

public class TimerSystem : MonoBehaviour
{
	//A: You can just use 1 text to show the value. Do not duplicate, this will make things hard to maintain
    [SerializeField] private TextMeshProUGUI countUpTimerText;
    [SerializeField] private TextMeshProUGUI countDownTimerText;

    private float timer;
    private float timeSet;
          
    public UnityEvent OnTimerEnd;

    private void Update()
    {
		//A: Nullcheck
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
