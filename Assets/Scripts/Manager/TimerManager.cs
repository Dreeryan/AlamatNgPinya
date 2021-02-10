using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : BaseManager<TimerManager>
{
    public static System.Action<float> OnTimerUpdated;


    private float curTime;

    public float CurTime => curTime;

    private Coroutine timerRoutine;

    public void ResetTimer()
    {
        curTime = 0;
    }

    public void StartTimer()
    {
        if (timerRoutine != null) return;
        ResetTimer();
        SceneLoader.Instance.ChangeScene("Timer", true);
        timerRoutine = StartCoroutine(TimerRoutine());
    }

    public void StopTimer()
    {
        StopCoroutine(timerRoutine);
        timerRoutine = null;
    }

    IEnumerator TimerRoutine()
    {
        for(; ; )
        {
            curTime += Time.deltaTime;
            OnTimerUpdated?.Invoke(curTime);
            yield return null;
        }
    }
}
