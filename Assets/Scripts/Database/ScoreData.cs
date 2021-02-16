using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : BaseData
{
    [Header("WinCheck")]
    [SerializeField] private int goal;
    public int Goal => goal;

    [Header("ScoreData")]
    [SerializeField] private float  baseScoreValue;
    [SerializeField] private float  secondsTarget;
    public float BaseScoreValue => baseScoreValue;
    public float SecondsTarget => secondsTarget;

    public float GetResultingScore(float secondsTaken)
    {
        return baseScoreValue * (secondsTarget / secondsTaken);
    }
}
