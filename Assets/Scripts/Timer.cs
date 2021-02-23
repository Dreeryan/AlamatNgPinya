    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime;

    public bool HasExceededTime( float TimeToWait)
    {
        if (elapsedTime >= TimeToWait)
        {
            return true;
        }
        else return false;
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
