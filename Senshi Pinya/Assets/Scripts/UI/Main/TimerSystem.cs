using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimerSystem : MonoBehaviour
{
    [SerializeField] float GetTimeLeft;
    [SerializeField] float maxTime;
    [SerializeField] bool isCountingUp;
    [SerializeField] bool isCountingDown;
    public UnityEvent OnTimerEnd;

    void Start()
    {
        
    }

    void Update()
    {
        if (isCountingUp == true && isCountingDown == false) StartCoroutine(StartCountUpTimer(1));
        if (isCountingDown == true && isCountingUp == false) StartCoroutine(StartCountDownTimer(1)); 
    }

    public IEnumerator StartCountUpTimer(float seconds)
    {
        Debug.Log("Counting up");
        GetTimeLeft = 0;
        GetTimeLeft += seconds * Time.deltaTime;
        if (GetTimeLeft >= maxTime) 
        {
            GetTimeLeft = 0;
            StopCoroutine(StartCountUpTimer(0));
        }

        yield return new WaitForSeconds(seconds);
    }

    public IEnumerator StartCountDownTimer(float seconds)
    {
        Debug.Log("Counting down");
        GetTimeLeft = maxTime;
        GetTimeLeft -= seconds * Time.deltaTime;
        if (GetTimeLeft <= 0)
        {
            GetTimeLeft = 0;
            StopCoroutine(StartCountDownTimer(0));
        }
        yield return new WaitForSeconds(seconds);
    }

}
