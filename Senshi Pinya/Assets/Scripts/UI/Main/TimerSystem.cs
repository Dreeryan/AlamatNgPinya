using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimerSystem : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] float maxTime;
    [SerializeField] bool isCountingUp;
    [SerializeField] bool isCountingDown;

    void Start()
    {
        currentTime = 0;
        currentTime = maxTime;
    }

    void Update()
    {
        if (isCountingUp == true && isCountingDown == false) StartCountUpTimer(); // Starts if isCountingUp is ticked
        if (isCountingDown == true && isCountingUp == false) StartCountDownTimer(); // Starts if isCountingDown is ticked
    }

    public void StartCountUpTimer() // Count Up Timer
    {
        Debug.Log("Counting up");
        currentTime += 1 * Time.deltaTime;
        if (currentTime >= maxTime) 
        {
            ResetTimer();
        }
    }

    public void StartCountDownTimer() // Count Down Timer
    {
        Debug.Log("Counting down");
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        if (isCountingUp == true && isCountingDown == false) currentTime = 0; // Resets CountUpTimer when reaching maxTime
        if (isCountingDown == true && isCountingUp == false) currentTime = maxTime; // Resets CountDownTimer when reaching maxTime
    }

}
