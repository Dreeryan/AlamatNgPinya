using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimerSystem : MonoBehaviour
{
    [SerializeField] float GetTimeLeft;
    [SerializeField] float maxTime;
    public UnityEvent OnTimerEnd;

    void Start()
    {
        GetTimeLeft = maxTime;
    }

    void Update()
    {
        StartCoroutine(StartCountUpTimer(1));
    }

    public IEnumerator StartCountUpTimer(float seconds)
    {
        //GetTimeLeft = maxTime;
        GetTimeLeft -= 1 * Time.deltaTime;
        if (GetTimeLeft <= 0)
        {
            GetTimeLeft = 0;
        }

        yield return new WaitForSeconds(seconds);

    }

    public IEnumerator StartCountDownTimer(float seconds)
    {
        //GetTimeLeft += 1 * Time.deltaTime;
        //if (GetTimeLeft <= 0)
        //{
        //    GetTimeLeft = 0;
        //}

        yield return new WaitForSeconds(seconds);

    }

}
