    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float elapsedTime { get; private set; }
    public bool hasTimedUp;
    public bool HasExceededTime( float TimeToWait)
    {
        if (elapsedTime >= TimeToWait)
        {
            hasTimedUp = true;
            return hasTimedUp;
        }
        else hasTimedUp = false;
        return hasTimedUp;
    }

    public void AddTime()
    {
        elapsedTime += Time.deltaTime;
    }


    public void ResetTimer()
    {
        elapsedTime = 0;
    }



}
